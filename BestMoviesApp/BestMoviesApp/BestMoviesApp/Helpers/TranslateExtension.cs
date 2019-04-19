using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BestMoviesApp.Helpers
{
    [ContentProperty("Text")]
    class TranslateExtension : IMarkupExtension
    {
        const string ResourceId = "BestMoviesApp.AppResources";

        static readonly Lazy<ResourceManager> resmgr = new Lazy<ResourceManager>(() => 
        new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            var config = ConfigHelper.GetConfig();
            var ci = new CultureInfo(config.Language);

            var translation = resmgr.Value.GetString(Text, ci);
            if (translation == null)
            {
				translation = Text;
            }
            return translation;
        }
    }
}

