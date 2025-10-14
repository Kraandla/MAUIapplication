using PizzaPlace.Models;

namespace PizzaPlace.Views;

public partial class PizzaDetails : ContentPage
{

    public PizzaDetails()
    {
        InitializeComponent();

        // Lisa testandmed (dummy info)
        BindingContext = new Pizza
        {
            
            Name = "Test Pizza",
            Size = 18,
            Toppings = "Cheese, Pepperoni, Olives",
            Sauce = "Tomato Basil",
            Price = 12.99,
            Image = "margherita.png"
        };
    }
    public PizzaDetails(Models.Pizza pizza)
	{
		InitializeComponent();
        this.BindingContext = pizza;
    }

    async void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();

    }

    async void MenuButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PizzaMenu());
    }

    private async void EditButton_Clicked(object sender, EventArgs e)
    {
        var pizza = BindingContext as PizzaPlace.Models.Pizza;
        await Navigation.PushModalAsync(new PizzaCreateUpdate(pizza));
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        var pizza = BindingContext as PizzaPlace.Models.Pizza;
        if (pizza == null)
        {
            await DisplayAlert("Error", "No pizza loaded.", "OK");
            return;
        }

        var confirm = await DisplayAlert("Delete pizza", "Are you sure you want to delete this pizza?", "Delete", "Cancel");
        if (!confirm) return;

        var db = new PizzaPlace.Data.DatabaseContext();
        var success = await db.DeleteItemAsync<PizzaPlace.Models.Pizza>(pizza);

        if (success)
        {
            await DisplayAlert("Deleted", "Pizza was deleted.", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Failed to delete pizza.", "OK");
        }
    }
}