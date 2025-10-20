using System.Collections.ObjectModel;
using PizzaPlace.Data;
using PizzaPlace.Models;

namespace PizzaPlace.Views;

public partial class PizzaMenu : ContentPage
{
	private readonly DatabaseContext _db = new DatabaseContext();
	private ObservableCollection<Pizza> _pizzas = new ObservableCollection<Pizza>();
	
	public PizzaMenu()
	{
		InitializeComponent();
        LoadPizza();
		PizzaMenuItems.ItemsSource = _pizzas;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //await LoadPizza();
    }

    //private async Task LoadPizza()
    //{
    //    var testPizza = new Pizza
    //    {
    //        Name = "Pepperoni",
    //        Size = 35,
    //        Toppings = "Pepperoni, Cheese",
    //        Sauce = "Tomato",
    //        Price = 10.0m,
    //        CreatedAt = DateTime.Now
    //    };

    //    var allPizzas = await _db.GetAllAsync<Pizza>();
    //    if (!allPizzas.Any(p => p.Name == testPizza.Name))
    //        await _db.AddItemAsync(testPizza);

    //    var pizzas = await _db.GetAllAsync<Pizza>();
    //    _pizzas.Clear();
    //    foreach (var p in pizzas)
    //        _pizzas.Add(p);

    //    PizzaMenuItems.IsVisible = true;
    //}

    private void PizzaMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}