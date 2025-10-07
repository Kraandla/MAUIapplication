using SQLite;

namespace PizzaPlace.Models
{
    public class Pizza
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Toppings { get; set; }
        public string Sauce { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set;
        public Pizza Clone() => MemberwiseClone() as Pizza;
        public (bool isValid, string errorMessage) Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return (false, "Name is required.");
            if (Size <= 0)
                return (false, "Size must be greater than zero.");
            if (string.IsNullOrWhiteSpace(Toppings))
                return (false, "At least one topping is required.");
            if(string.IsNullOrWhiteSpace(Sauce))
                return (false, "Sauce is required.");
            if (Price <= 0)
                return (false, "Price cannot be negative.");
            return (true, null);
        }
    }
}
