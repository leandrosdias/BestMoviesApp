using BestMoviesApp.Interfaces;
using BestMoviesApp.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BestMoviesApp.Services
{
    internal class NavigationService : INavigationService
    {
        public Task NavigateToPageChoiced(ItemChoice itemChoice)
        {
            switch (itemChoice)
            {

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
