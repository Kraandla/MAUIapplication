using SQLite;

namespace PizzaPlace.Models
{
    public class Pizza
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Size { get; set; }
        public string Toppings { get; set; }
        public string Sauce { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public Pizza Clone() => MemberwiseClone() as Pizza;
        public (bool isValid, string errorMessage) Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return (false, "Pizza name is required.");
            if (Size <= 0)
                return (false, "Pizza size must be greater than zero.");
            if (string.IsNullOrWhiteSpace(Toppings))
                return (false, "At least one topping is required.");
            if(string.IsNullOrWhiteSpace(Sauce))
                return (false, "The pizza needs sauce on it.");
            if (Price <= 0)
                return (false, "Your pizza needs to be priced above 0.");
            return (true, null);
        }
    }
}
