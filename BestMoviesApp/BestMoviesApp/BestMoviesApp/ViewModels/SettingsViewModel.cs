using BestMoviesApp.Helpers;
using BestMoviesApp.Interfaces;
using BestMoviesApp.Models;
using BestMoviesApp.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BestMoviesApp.ViewModels
{
    internal class SettingsViewModel : BaseViewModel
    {
        public ICommand SaveCommand { get; set; }
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;

        public List<Language> Languages { get; set; }
        private Language _selectedLanguage;
        public Language SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                _selectedLanguage = value;
                Notify("SelectedLanguage");
            }
        }

        public SettingsViewModel()
        {
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();
            SaveCommand = new Command(SaveConfig);

            Languages = new List<Language>
            {
                new Language{Code = "en-US", Description = UtilsFunctions.GetStringLangResource("Desc_en-US")},
                new Language{Code = "pt-BR", Description = UtilsFunctions.GetStringLangResource("Desc_pt-BR")},
            };

            var config = ConfigHelper.GetConfig();
            SelectedLanguage = Languages.FirstOrDefault(x => x.Code == config.Language);
        }

        private async void SaveConfig()
        {
            try
            {
                var config = ConfigHelper.GetConfig();
                config.Language = SelectedLanguage.Code;
                ConfigHelper.InsertOrUpdateConfig(config);
                await _messageService.ShowAsync(UtilsFunctions.GetStringLangResource("SaveConfigSucess"));
                await _navigationService.NavigateToMenuPage();
            }
            catch(Exception e)
            {
                Debug.Write(e.Message);
                await _messageService.ShowAsync(UtilsFunctions.GetStringLangResource("SystemError"));
            }
        }
    }
}
