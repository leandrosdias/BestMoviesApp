using BestMoviesApp.Helpers;
using BestMoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestMoviesApp.ViewModels
{
    class UpcomingMoviesViewModel : BaseViewModel
    {
        ObservableCollection<MovieLineGrid> moviesGrid;
        public ObservableCollection<MovieLineGrid> MoviesGrid
        {
            get => moviesGrid;
            set { moviesGrid = value; Notify("MoviesGrid"); }
        }

        private int _page;
        public int Page
        {
            get => _page;
            set { _page = value; Notify("Page"); }
        }

        public UpcomingMoviesViewModel(List<Movie> movies)
        {
            MoviesGrid = new ObservableCollection<MovieLineGrid>();
            MoviesGrid.CollectionChanged += Movies_CollectionChanged;
            Page = 1;
            MovieLineGridHelper.AddMoviesInScreen(MoviesGrid, movies);
        }

        private void Movies_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Notify("MoviesGrid");
        }

        public async Task GetNextPageAsync()
        {
            Page++;
            var movies = await MovieHelper.GetUpcommingMoviesAsync(_page);
            MovieLineGridHelper.AddMoviesInScreen(MoviesGrid, movies);
        }
    }
}
