using System.Collections.ObjectModel;
using System.Numerics;
using PizzaPlace.Data;
using PizzaPlace.Models;

namespace PizzaPlace.Views;

public partial class PizzaMenu : ContentPage
{
    private readonly DatabaseContext _db = new DatabaseContext();
    private readonly ObservableCollection<Pizza> _pizzas = new ObservableCollection<Pizza>();

    public PizzaMenu()
    {
        InitializeComponent();
        PizzaMenuItems.ItemsSource = _pizzas;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadPizzas();
    }

    private async Task LoadPizzas()
    {
        try
        {
            var pizzas = await _db.GetAllAsync<Pizza>();

            _pizzas.Clear();
            foreach (var pizza in pizzas)
                _pizzas.Add(pizza);

            PizzaMenuItems.IsVisible = _pizzas.Any();
        }

        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load pizzas: {ex.Message}", "OK");
        }
    }

    private async void PizzaMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

        var selectedPizza = e.CurrentSelection.FirstOrDefault() as Pizza;

        //wait Navigation.PushAsync(new PizzaDetails(selectedPizza));

    }
}