using BestMoviesApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BestMoviesApp.Services
{
    internal class MessageService : IMessageService
    {
        public async Task ShowAsync(string message)
        {
            await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Best Movies", message, "OK");
        }

        public async Task<bool> ShowAnswerAsync(string message, string ok = "OK", string cancel = "CANCEL")
        {
            return await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Best Movies", message, ok, cancel);
        }
    }
}
