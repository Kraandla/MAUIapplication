
namespace PizzaPlace.Views;

public partial class PizzaMenu : ContentPage
{
	public PizzaMenu()
	{
		InitializeComponent();
	}

    async void Create(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.PizzaCreateUpdate());
    }
    async void Details(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.PizzaDetails());
    }
}