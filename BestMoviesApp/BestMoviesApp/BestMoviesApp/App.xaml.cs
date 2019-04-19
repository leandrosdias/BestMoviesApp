﻿using Plugin.Multilingual;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BestMoviesApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AppResources.Culture = CrossMultilingual.Current.DeviceCultureInfo;
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
