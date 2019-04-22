﻿using BestMoviesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BestMoviesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviePage : ContentPage
    {
        public MoviePage(Movie movie)
        {
            InitializeComponent();
            BindingContext = new MovieViewModel(movie);
        }
    }
}