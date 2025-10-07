using Microsoft.Extensions.Logging;

namespace PizzaPlace
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Lato-Regular.ttf", "Regular");
                    fonts.AddFont("Lato-Light.ttf", "Light");
                    fonts.AddFont("Montserrat-Bold.ttf", "Bold");
                    fonts.AddFont("Montserrat-Semibold.ttf", "Medium");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
