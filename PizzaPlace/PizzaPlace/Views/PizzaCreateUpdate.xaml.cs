using PizzaPlace.Models;
using PizzaPlace.ViewModels;

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
}