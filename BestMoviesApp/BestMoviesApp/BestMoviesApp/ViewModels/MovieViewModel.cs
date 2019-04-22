using BestMoviesApp.Database;
using BestMoviesApp.Database.ModelAccessor;
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

        private string _favoriteColor;
        public string FavoriteColor
        {
            get => _favoriteColor;
            set { _favoriteColor = value; Notify("FavoriteColor"); }
        }

        private Movie _movie;
        
        public ICommand FavoriteCommand { get; set; }
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;


        public MovieViewModel(Movie movie)
        {
            MovieTitle = movie.Title;
            MovieOverview = movie.Overview;
            SetReleaseDate(movie);
            Banner = "https://image.tmdb.org/t/p/w500/" + movie.BackdropPath;
            Poster = "https://image.tmdb.org/t/p/w500/" + movie.PosterPath;

            _movie = movie;
            SetFavoriteColor();

            FavoriteCommand = new Command(FavoriteMovie);
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();

        }

        private void SetReleaseDate(Movie movie)
        {
            var releaseDate = DateTime.ParseExact(movie.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var config = ConfigHelper.GetConfig();
            var ci = new CultureInfo(config.Language);
            MovieReleaseDate = releaseDate.ToString("dd / MMMM / yyyy", ci);
        }

        public void FavoriteMovie()
        {
            try
            {
                var modelAcessor = new SqlDataAccessor();

                if (!_movie.IsFavorite)
                {
                    _movie.IsFavorite = true;
                    var accessor = new MovieAccessor(modelAcessor, _movie);
                    accessor.InsertOrUpdate();
                }
                else
                {
                    var accessor = new MovieAccessor(modelAcessor, _movie);
                    accessor.Delete();
                    _movie.IsFavorite = false;
                }

                SetFavoriteColor();
            }
            catch(Exception e)
            {
                
            }
        }

        private void SetFavoriteColor()
        {
            FavoriteColor = _movie.IsFavorite ? "#ffff00" : "#ffffff";
        }
    }
}
