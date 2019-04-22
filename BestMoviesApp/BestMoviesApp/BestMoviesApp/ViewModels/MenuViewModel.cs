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
            try
            {
                if(itemChoice == ItemChoice.UpcomingMovies || itemChoice == ItemChoice.TopRatedMovies)
                {
                    if (!CrossConnectivity.Current.IsConnected)
                    {
                        await ShowErrorConnection(itemChoice);
                        return;
                    }

                    var movies = itemChoice == ItemChoice.UpcomingMovies ? await MovieHelper.GetUpcommingMoviesAsync(1) :
                        await MovieHelper.GetTopRatedMoviesAsync(1);
                    await _navigationService.NavigateToPageChoiced(itemChoice, movies);
                    return;
                }

                await _navigationService.NavigateToPageChoiced(itemChoice);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                await _messageService.ShowAsync(UtilsFunctions.GetStringLangResource("SystemError"));
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
