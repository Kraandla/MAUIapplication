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

    async void BackButton_Clicked(System.Object sender, System.EventArgs e)
        => Application.Current.MainPage = new NavigationPage(new PizzaMenu());
}