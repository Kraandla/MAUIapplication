using Microsoft.Maui.Controls;

namespace PizzaPlace.Views;

public partial class StartPage : ContentPage
{
    bool _animated;

    public StartPage()
    {
        InitializeComponent();
    }

    async void PizzaMenu_Clicked(object sender, EventArgs e)
        => Application.Current.MainPage = new NavigationPage(new PizzaMenu());
}