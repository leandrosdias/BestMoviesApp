using BestMoviesApp.Database;
using BestMoviesApp.Database.ModelAccessor;
using BestMoviesApp.Helpers;
using BestMoviesApp.Interfaces;
using BestMoviesApp.Utils;
using Plugin.Connectivity;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BestMoviesApp.ViewModels
{
    class MenuViewModel : BaseViewModel
    {
        private bool _loading;
        public bool Loading
        {
            get => _loading;
            set { _loading = value; Notify("Loading"); }
        }
        public ICommand ButtonCommand { get; set; }
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;

        public MenuViewModel()
        {
            ButtonCommand = new Command<ItemChoice>(ButtonClick);
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();
        }

        private async void ButtonClick(ItemChoice itemChoice)
        {
            Loading = true;
            try
            {
                if(itemChoice == ItemChoice.UpcomingMovies || itemChoice == ItemChoice.TopRatedMovies)
                {
                    if (!CrossConnectivity.Current.IsConnected)
                    {
                        await ShowErrorConnection(itemChoice);
                        Loading = false;
                        return;
                    }

                    var movies = itemChoice == ItemChoice.UpcomingMovies ? await MovieHelper.GetUpcommingMoviesAsync(1) :
                        await MovieHelper.GetTopRatedMoviesAsync(1);
                    await _navigationService.NavigateToPageChoiced(itemChoice, movies);
                    Loading = false;
                    return;
                }

                if(itemChoice == ItemChoice.FavoritesMovies)
                {
                    var modelAcessor = new SqlDataAccessor();
                    var accessor = new MovieAccessor(modelAcessor, null);
                    var moviesFavorited = accessor.GetMovies();
                    if(moviesFavorited == null || moviesFavorited.Count <= 0)
                    {
                        await _messageService.ShowAsync(UtilsFunctions.GetStringLangResource("ErroWithoutFavorites"));
                        Loading = false;
                        return;
                    }
                    await _navigationService.NavigateToPageChoiced(itemChoice, moviesFavorited);
                    Loading = false;
                    return;
                }

                await _navigationService.NavigateToPageChoiced(itemChoice);
                Loading = false;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                await _messageService.ShowAsync(UtilsFunctions.GetStringLangResource("SystemError"));
                Loading = false;
            }
        }

        private async Task ShowErrorConnection(ItemChoice itemChoice)
        {
            var screen = itemChoice == ItemChoice.UpcomingMovies ?
                UtilsFunctions.GetStringLangResource("TitleUpcoming") :
                UtilsFunctions.GetStringLangResource("TitleTopRated");

            var message = string.Format(UtilsFunctions.GetStringLangResource("ScreenNotAllowDisconnected"), screen);
            await _messageService.ShowAsync(message);
        }
    }
}
