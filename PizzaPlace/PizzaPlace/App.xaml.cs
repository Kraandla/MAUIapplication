#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

using PizzaPlace.Data;

namespace PizzaPlace
{
    public partial class App : Application
    {
        const int WindowWidth = 720;
        const int WindowHeight = 1280;
        public App()
        {
            InitializeComponent();
            InitializeDatabase();

            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
            {
                #if WINDOWS
                var mauiWindow = handler.VirtualView;
                var nativeWindow = handler.PlatformView;
                nativeWindow.Activate();
                IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
                AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
                #endif
            });
        }

        private async void InitializeDatabase()
        {
            var db = new DatabaseContext();
            await db.SeedDataAsync();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Mainpage code =
            //return new Window(new AppShell());
            return new Window(new NavigationPage(new Views.StartPage()));
        }
    }
}