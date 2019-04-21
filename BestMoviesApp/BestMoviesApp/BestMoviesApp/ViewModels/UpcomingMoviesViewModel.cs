﻿using BestMoviesApp.Helpers;
using BestMoviesApp.Interfaces;
using BestMoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

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

        public List<Movie> _movies;

        private int _page;
        public int Page
        {
            get => _page;
            set { _page = value; Notify("Page"); }
        }

        public ICommand SelectMovieCommand { get; set; }
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;
        public UpcomingMoviesViewModel(List<Movie> movies)
        {
            MoviesGrid = new ObservableCollection<MovieLineGrid>();
            MoviesGrid.CollectionChanged += Movies_CollectionChanged;
            SelectMovieCommand = new Command<int>(GoMovieDetails);
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();

            Page = 1;
            _movies = movies;
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
            _movies.AddRange(movies);
            MovieLineGridHelper.AddMoviesInScreen(MoviesGrid, movies);
        }

        public async void GoMovieDetails(int movieId)
        {
            try
            {
                var movie = _movies.FirstOrDefault(x => x.Id == movieId);
                if (movie == null)
                {
                    await _messageService.ShowAsync("");
                    return;
                }

                await _navigationService.NavigateToMoviePage(movie);
            }
            catch(Exception e)
            {
                Debug.Write(e.Message);
            }
        }

        public void UpdateListWithSearch(string searchString)
        {
            var movies = string.IsNullOrWhiteSpace(searchString) ? _movies :
                _movies.Where(x => x.Title.ToLower().Contains(searchString.ToLower())).ToList();
            MoviesGrid = new ObservableCollection<MovieLineGrid>();
            MovieLineGridHelper.AddMoviesInScreen(MoviesGrid, movies);
        }
    }
}
