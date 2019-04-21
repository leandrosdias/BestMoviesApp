using BestMoviesApp.Helpers;
using BestMoviesApp.Interfaces;
using System;
using System.Globalization;
using System.Windows.Input;
using Xamarin.Forms;

namespace BestMoviesApp.ViewModels
{
    class MovieViewModel : BaseViewModel
    {
        private string _movieTitle;
        public string MovieTitle
        {
            get => _movieTitle;
            set { _movieTitle = value; Notify("MovieTitle"); }
        }

        private string _movieReleasedDate;
        public string MovieReleaseDate
        {
            get => _movieReleasedDate;
            set { _movieReleasedDate = value; Notify("MovieReleaseDate"); }
        }

        private string _movieOverview;
        public string MovieOverview
        {
            get => _movieOverview;
            set { _movieOverview = value; Notify("MovieOverview"); }
        }

        private string _banner;
        public string Banner
        {
            get => _banner;
            set { _banner = value; Notify("Banner"); }
        }

        private string _poster;
        public string Poster
        {
            get => _poster;
            set { _poster = value; Notify("Poster"); }
        }

        public ICommand FavoriteCommand { get; set; }
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;


        public MovieViewModel(Movie movie)
        {
            MovieTitle = movie.Title;

            var releaseDate = DateTime.ParseExact(movie.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var config = ConfigHelper.GetConfig();
            var ci = new CultureInfo(config.Language);
            MovieReleaseDate = releaseDate.ToString("dd / MMMM / yyyy", ci);

            MovieOverview = movie.Overview;
            Banner = "https://image.tmdb.org/t/p/w500/" + movie.BackdropPath;
            Poster = "https://image.tmdb.org/t/p/w500/" + movie.PosterPath;

            FavoriteCommand = new Command(FavoriteMovie);
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();

        }

        public void FavoriteMovie()
        {

        }
    }
}
