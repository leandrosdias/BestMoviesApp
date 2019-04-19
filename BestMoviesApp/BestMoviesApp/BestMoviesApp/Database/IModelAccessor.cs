using System;
using System.Collections.Generic;
using System.Text;

namespace BestMoviesApp.Database
{
    interface IModelAccessor
    {
        void Insert(object model);
        void Update(object model);
        void Delete(object model);
        List<T> GetAll<T>() where T : new();
    }
}
