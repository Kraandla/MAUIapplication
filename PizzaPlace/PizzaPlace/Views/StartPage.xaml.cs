using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace PizzaPlace.Views;

public partial class StartPage : ContentPage
{
    readonly List<string> _images = new()
    {
        "pizza1.png",
        "pizza2.png",
        "pizza3.png",
        "pizza4.png"
    };

    int _currentIndex = 0;
    bool _running = false;

    public StartPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_running)
            return;

        _running = true;

        while (_running)
        {
            SlideshowImage.Source = _images[_currentIndex];

            //fade in
            await SlideshowImage.FadeTo(1, 800, Easing.CubicIn);

            //stay visible for a moment
            await Task.Delay(4000);

            //fade out
            await SlideshowImage.FadeTo(0, 1000, Easing.CubicOut);

            _currentIndex = (_currentIndex + 1) % _images.Count;
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _running = false;
    }

    async void PizzaMenu_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.PizzaMenu());
    }
}
