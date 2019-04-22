using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BestMoviesApp.Utils
{
    internal class FileUtils
    {


        public static string GetCurrentFolderPath()
        {
            var folder = GetCurrentFolder();
            return folder?.Path;
        }

        public static IFolder GetCurrentFolder()
        {
            var folder = FileSystem.Current.LocalStorage;
            return folder;
        }
    }
}
