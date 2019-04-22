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
    public partial class TopRatedPage : ContentPage
    {
        public TopRatedPage(List<Movie> movies)
        {
            InitializeComponent();
            BindingContext = new TopRatedViewModel(movies);
        }

        private void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var nItems = int.Parse(Page.Text) * 20 / 6;
            if (nItems == e.ItemIndex)
            {
                var viewModel = (TopRatedViewModel)BindingContext;
                viewModel.GetNextPageAsync();
            }
        }

        private void MovieSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = (TopRatedViewModel)BindingContext;
            viewModel.UpdateListWithSearch(e.NewTextValue);
        }
    }
}