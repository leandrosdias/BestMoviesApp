using BestMoviesApp.Database;
using BestMoviesApp.Database.ModelAcessor;
using BestMoviesApp.Models;
using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestMoviesApp.Helpers
{
    class ConfigHelper
    {
        public static void InsertConfig(Config config)
        {
            var modelAcessor = new SqlDataAccessor();
            var configAcessor = new ConfigAccessor(modelAcessor, config);
            configAcessor.Insert();
        }

        public static void InsertOrUpdateConfig(Config config)
        {
            var modelAcessor = new SqlDataAccessor();
            var configAcessor = new ConfigAccessor(modelAcessor, config);
            configAcessor.InsertOrUpdate();
        }

        public static Config GetConfig()
        {
            var modelAcessor = new SqlDataAccessor();
            var configAcessor = new ConfigAccessor(modelAcessor, new Config());
            var config = configAcessor.GetConfig();
            if (config == null)
            {
                config = new Config { Language = CrossMultilingual.Current.DeviceCultureInfo.IetfLanguageTag };
                configAcessor.InsertOrUpdate(config);
            }

            return config;
        }
    }
}
