using BestMoviesApp.Helpers;
using BestMoviesApp.Interfaces;
using BestMoviesApp.Services;
using BestMoviesApp.Views;
using System.Globalization;
using Xamarin.Forms;

namespace BestMoviesApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var config = ConfigHelper.GetConfig();
            AppResources.Culture = new CultureInfo(config.Language);

            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<INavigationService, NavigationService>();

            MainPage = new NavigationPage(new MenuPage());
        }

        

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
