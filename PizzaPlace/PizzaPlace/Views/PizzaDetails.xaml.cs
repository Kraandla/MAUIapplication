namespace PizzaPlace.Views;

public partial class PizzaDetails : ContentPage
{
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
}