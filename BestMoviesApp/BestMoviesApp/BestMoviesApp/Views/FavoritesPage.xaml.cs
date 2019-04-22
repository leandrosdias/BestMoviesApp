using BestMoviesApp.ViewModels;
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
    public partial class FavoritesPage : ContentPage
    {
        public FavoritesPage(List<Movie> movies)
        {
            InitializeComponent();
            BindingContext = new FavoritesViewModel(movies);
        }

        private void MovieSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = (FavoritesViewModel)BindingContext;
            viewModel.UpdateListWithSearch(e.NewTextValue);
        }
    }
}