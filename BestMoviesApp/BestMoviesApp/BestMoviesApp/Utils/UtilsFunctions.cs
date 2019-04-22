using BestMoviesApp.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;

namespace BestMoviesApp.Utils
{
    internal class UtilsFunctions
    {
        public static string GetStringLangResource(string key)
        {
            try
            {
                var resmgr = new Lazy<ResourceManager>(() =>
                new ResourceManager("BestMoviesApp.AppResources", typeof(TranslateExtension).GetTypeInfo().Assembly));
                var config = ConfigHelper.GetConfig();
                var ci = new CultureInfo(config.Language);

                return resmgr.Value.GetString(key, ci);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
