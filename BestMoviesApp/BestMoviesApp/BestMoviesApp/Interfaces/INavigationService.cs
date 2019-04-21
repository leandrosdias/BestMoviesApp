using BestMoviesApp.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BestMoviesApp.Interfaces
{
    internal interface INavigationService
    {
        Task NavigateToPageChoiced(ItemChoice itemChoice, List<Movie> movies = null);
        Task NavigateToMenu();
    }
}
