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
        SizeChanged += OnSized;
    }

    void OnSized(object? sender, EventArgs e)
    {
        if (Width <= 0 || Height <= 0)
            return;

        double imgWidth = Width * 0.8;
        SlideshowImage.WidthRequest = imgWidth;
        SlideshowImage.HeightRequest = imgWidth;
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
            SlideshowImage.Opacity = 0;
            SlideshowImage.TranslationY = -SlideshowImage.HeightRequest * 0.1;

            await Task.WhenAll(
                SlideshowImage.FadeTo(1, 800, Easing.CubicIn),
                SlideshowImage.TranslateTo(0, 0, 800, Easing.CubicOut)
            );

            await Task.Delay(3500);

            await SlideshowImage.FadeTo(0, 1000, Easing.CubicOut);

            _currentIndex = (_currentIndex + 1) % _images.Count;
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _running = false;
        SlideshowImage.CancelAnimations();
    }

    async void PizzaMenu_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.PizzaMenu());
    }

    async void CreatePizza_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PizzaCreateUpdate());
    }

    async void MenuButton_Clicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet(
            "Navigate to:",
            "Cancel",
            null,
         
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