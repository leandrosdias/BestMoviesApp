using BestMoviesApp.Interfaces;
using BestMoviesApp.Utils;
using BestMoviesApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BestMoviesApp.Services
{
    internal class NavigationService : INavigationService
    {
        public async Task NavigateToPageChoiced(ItemChoice itemChoice)
        {
            switch (itemChoice)
            {
                case ItemChoice.UpcomingMovies:
                    await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new UpcomingMoviesPage());
                    break;

                case ItemChoice.TopRatedMovies:
                    await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new TopRatedPage());
                    break;

                case ItemChoice.Settings:
                    await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new SettingsPage());
                    break;

                case ItemChoice.FavoritesMovies:
                    await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new FavoritesPage());
                    break;


                default:
                    throw new NotImplementedException();
            }
        }
    }
}
