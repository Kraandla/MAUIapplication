using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PizzaPlace.Models;
using SQLite;

namespace PizzaPlace.Data
{
    public class DatabaseContext
    {
        private const string DbName = "PIZZAdb";
        private static string DbPath = Path.Combine(".", DbName);
        private SQLiteAsyncConnection _connection;

        private SQLiteAsyncConnection Database =>
        (_connection ??= new SQLiteAsyncConnection(DbPath,
            SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache));
        public async Task<IEnumerable<TTable>> GetAllAsync<TTable>() where TTable : class, new()
        {
            var table = await GetTableAsync<TTable>();
            return await table.ToListAsync();
        }

        public async Task<AsyncTableQuery<TTable>> GetTableAsync<TTable>() where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return Database.Table<TTable>();
        }

        public async Task CreateTableIfNotExists<TTable>() where TTable : class, new()
        {
            await Database.CreateTableAsync<TTable>();
        }

        private async Task<TResult> Execute<TTable, TResult>(Func<Task<TResult>> action) where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return await action();
        }

        public async Task<TTable> GetItemByKeyAsync<TTable>(object primaryKey) where TTable : class, new()
        {
            return await Execute<TTable, TTable>(async () => await Database.GetAsync<TTable>(primaryKey));
        }
        public async Task<bool> AddItemAsync<TTable>(TTable item) where TTable : class, new()
        {
            return await Execute<TTable, bool>(async () => await Database.InsertAsync(item) > 0);
        }

        public async Task<bool> UpdateItemAsync<TTable>(TTable item) where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return await Database.UpdateAsync(item) > 0;
        }

        public async Task<bool> DeleteItemAsync<TTable>(TTable item) where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return await Database.DeleteAsync(item) > 0;
        }
        public async Task<bool> DeleteItemByKeyAsync<TTable>(object primaryKey) where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return await Database.DeleteAsync<TTable>(primaryKey) > 0;
        }

        public async ValueTask DisposeAsync() => await _connection.CloseAsync();

        public async Task<IEnumerable<TTable>> GetFilteredAsync<TTable>(Expression<Func<TTable, bool>> predicate)
            where TTable : class, new()
        {
            var table = await GetTableAsync<TTable>();
            return await table.Where(predicate).ToListAsync();
        }
        public async Task SeedDataAsync()
        {

            var existingPizzas = await GetAllAsync<Pizza>();
            if (existingPizzas.Any())
                return; // Data already seeded


            var pizzas = new List<Pizza>
               {
                   new Pizza { Name = "Margherita", Size=18, Price = 8.99, Toppings = "Classic tomato and mozzarella", Sauce="Tomato",  Image = "margherita.png"},
                   new Pizza { Name = "Pepperoni", Size=18,   Price = 10.99, Toppings = "Pepperoni and cheese", Sauce="ketsup", Image = "pepperoni.png"},
                   new Pizza { Name = "Veggie Supreme", Size=18,  Price = 11.99, Toppings = "Fresh vegetables", Sauce="majonees",Image = "seafood.png"},
                   new Pizza { Name = "Hawaiian", Size=18,  Price = 10.49, Toppings = "Ham and pineapple", Sauce="thsillikaste", Image = "hawwaiian.png" }
               };

            foreach (var pizza in pizzas)
            {
                await AddItemAsync(pizza);
            }

        }
    }
}
