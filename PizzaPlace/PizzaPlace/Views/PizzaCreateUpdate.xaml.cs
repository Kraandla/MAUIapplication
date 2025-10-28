using PizzaPlace.Models;
using PizzaPlace.ViewModels;
using Microsoft.Maui.Media;

namespace PizzaPlace.Views;

public partial class PizzaCreateUpdate : ContentPage
{
    private Pizza? pizza;

    public PizzaCreateUpdate()
    {
        InitializeComponent();
        BindingContext = new CreateUpdateViewModel();
    }

    public PizzaCreateUpdate(Pizza pizza)
    {
        InitializeComponent();
        BindingContext = new CreateUpdateViewModel(pizza);
    }

    async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    async void MenuButton_Clicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet(
            "Go to:",
            "Cancel",
            null,
            "StartPage",
            "PizzaMenu",
            "PizzaCreate"
        );

        switch (action)
        {
            case "StartPage":
                await Navigation.PushAsync(new StartPage());
                break;
            case "PizzaMenu":
                await Navigation.PushAsync(new PizzaMenu());
                break;
            case "PizzaCreate":
                await Navigation.PushAsync(new PizzaCreateUpdate());
                break;
            default:
                // Cancel or closed, do nothing
                break;
        }
    }


}