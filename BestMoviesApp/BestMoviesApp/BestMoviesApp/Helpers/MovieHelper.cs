using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BestMoviesApp.Helpers
{
    class MovieHelper
    {
        public static async Task<List<Movie>> GetUpcommingMoviesAsync(int page)
        {
            try
            {
                var config = ConfigHelper.GetConfig();

                var endoint = $"https://api.themoviedb.org/3/movie/upcoming?api_key=1f54bd990f1cdfb230adb312546d765d&language={config.Language}&page={page}";
                var client = new HttpClient();

                using (var request = new HttpRequestMessage(new HttpMethod("GET"), endoint))
                {
                    var response = await client.SendAsync(request);
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResultUpcomingMovies>(jsonResponse);
                    ConfigHelper.InsertOrUpdateConfig(config);

                    return result.Movies.ToList();
                }
            }
            catch(Exception e)
            {
                Debug.Write(e.Message);
                return null;
            }
        }
    }
}
