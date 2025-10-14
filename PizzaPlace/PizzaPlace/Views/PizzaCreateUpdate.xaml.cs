using PizzaPlace.Models;

namespace PizzaPlace.Views;

public partial class PizzaCreateUpdate : ContentPage
{
    private Pizza? pizza;

    public PizzaCreateUpdate()
	{
		InitializeComponent();
	}

    public PizzaCreateUpdate(Pizza? pizza)
    {
        InitializeComponent(); // Ensure XAML is loaded
        this.pizza = pizza;
        BindingContext = pizza;
    }
}