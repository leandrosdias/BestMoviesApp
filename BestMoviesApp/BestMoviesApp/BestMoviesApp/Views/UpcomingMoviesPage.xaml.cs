using BestMoviesApp.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BestMoviesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpcomingMoviesPage : ContentPage
    {
        public UpcomingMoviesPage(List<Movie> movies)
        {
            InitializeComponent();
            BindingContext = new UpcomingMoviesViewModel(movies);

        }

        private void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var nItems = int.Parse(Page.Text) * 20 / 6;
            if (nItems == e.ItemIndex)
            {
                var viewModel = (UpcomingMoviesViewModel)BindingContext;
                viewModel.GetNextPageAsync();
            }
        }
    }
}