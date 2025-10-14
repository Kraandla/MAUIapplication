namespace PizzaPlace.Views;

public partial class PizzaCreateUpdate : ContentPage
{
	public PizzaCreateUpdate()
	{
		InitializeComponent();
	}

    async void BackButton_Clicked(System.Object sender, System.EventArgs e)
        => Application.Current.MainPage = new NavigationPage(new PizzaMenu());
}