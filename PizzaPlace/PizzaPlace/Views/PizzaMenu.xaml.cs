
namespace PizzaPlace.Views;

public partial class PizzaMenu : ContentPage
{
	public PizzaMenu()
	{
		InitializeComponent();
	}

    async void Create(System.Object sender, System.EventArgs e)
        => Application.Current.MainPage = new NavigationPage(new PizzaCreateUpdate());
    async void Details(System.Object sender, System.EventArgs e)
        => Application.Current.MainPage = new NavigationPage(new PizzaDetails());
}