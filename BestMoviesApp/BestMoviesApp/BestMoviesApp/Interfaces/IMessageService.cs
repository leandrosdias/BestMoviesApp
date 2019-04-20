using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BestMoviesApp.Interfaces
{
    internal interface IMessageService
    {
        Task ShowAsync(string message);
        Task<bool> ShowAnswerAsync(string message, string ok = "OK", string cancel = "CANCEL");

    }
}
