using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestMoviesApp.Database.ModelAccessor
{
    class MovieAccessor
    {
        private readonly IModelAccessor _modelAcessor;
        private readonly Movie _movie;

        public MovieAccessor(IModelAccessor modelAcessor, Movie movie)
        {
            _modelAcessor = modelAcessor;
            _movie = movie;
        }

        public void Insert()
        {
            _modelAcessor.Insert(_movie);
        }

        public void Insert(Movie movie)
        {
            _modelAcessor.Insert(movie);
        }

        public void Delete()
        {
            _modelAcessor.Delete(_movie);
        }

        public void Delete(Movie movie)
        {
            _modelAcessor.Delete(movie);
        }

        public void Update()
        {
            _modelAcessor.Update(_movie);
        }

        public void Update(Movie movie)
        {
            _modelAcessor.Update(movie);
        }

        public void InsertOrUpdate(Movie movie)
        {
            var pMovie = GetMovies().FirstOrDefault(x => x.Id == movie.Id);
            if (pMovie == null)
            {
                Insert(movie);
            }
            else
            {
                Update(movie);
            }
        }

        public void InsertOrUpdate()
        {
            var movie = GetMovies().FirstOrDefault(x=>x.Id == _movie.Id);
            if(movie == null)
            {
                Insert();
            }
            else
            {
                Update();
            }
        }

        public List<Movie> GetMovies()
        {
            return _modelAcessor.GetAll<Movie>();
        }
    }
}
