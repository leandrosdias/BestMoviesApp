using BestMoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BestMoviesApp.Helpers
{
    class MovieLineGridHelper
    {
        public static void AddMoviesInScreen(ObservableCollection<MovieLineGrid> Movies, List<Movie> movies)
        {
            int i = 0;
            if (Movies.Count > 0)
            {
                var lastLine = Movies.LastOrDefault();
                if (lastLine != null)
                {
                    if (string.IsNullOrWhiteSpace(lastLine.Title2))
                    {
                        lastLine.Id2 = movies[0].Id;
                        lastLine.Title2 = movies[0].Title;
                        lastLine.Image2 = "https://image.tmdb.org/t/p/w500/" + movies[0].PosterPath;
                        i++;
                    }

                    if (string.IsNullOrWhiteSpace(lastLine.Title3))
                    {
                        lastLine.Id3 = movies[0].Id;
                        lastLine.Title3 = movies[0].Title;
                        lastLine.Image3 = "https://image.tmdb.org/t/p/w500/" + movies[0].PosterPath;
                        i++;
                    }
                }
            }

            while (i < movies.Count)
            {
                var line = new MovieLineGrid
                {
                    Id1 = movies[i].Id,
                    Image1 = "https://image.tmdb.org/t/p/w500/" + movies[i].PosterPath,
                    Title1 = movies[i].Title
                };

                if (movies.Count - i > 1)
                {
                    line.Id2 = movies[i + 1].Id;
                    line.Image2 = "https://image.tmdb.org/t/p/w500/" + movies[i + 1].PosterPath;
                    line.Title2 = movies[i + 1].Title;
                }

                if (movies.Count - i > 2)
                {
                    line.Id3 = movies[i + 2].Id;
                    line.Image3 = "https://image.tmdb.org/t/p/w500/" + movies[i + 2].PosterPath;
                    line.Title3 = movies[i + 2].Title;
                }

                Movies.Add(line);

                i += 3;
            }
        }
    }
}
