using BestMoviesApp.Models;
using BestMoviesApp.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestMoviesApp.Database
{
    public class SqlDataAccessor : IDisposable, IModelAccessor
    {
        private SQLiteConnection _sqLiteConnection;
        private static string _sDatabasePath;

        public SqlDataAccessor()
        {
            _sqLiteConnection = GetConnection();
        }

        public SQLiteConnection GetConnection()
        {
            _sqLiteConnection = ConfigureConnection();
            return _sqLiteConnection;
        }

        private static SQLiteConnection ConfigureConnection()
        {
            _sDatabasePath = System.IO.Path.Combine(FileUtils.GetCurrentFolderPath(), "BestMovies.db3");
            return new SQLiteConnection(_sDatabasePath);
        }

        public void Dispose()
        {
            _sqLiteConnection?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Insert(object model)
        {
            _sqLiteConnection.CreateTable(model.GetType());
            _sqLiteConnection.Insert(model);
        }

        public void Update(object model)
        {
            _sqLiteConnection.CreateTable(model.GetType());
            _sqLiteConnection.Update(model);
        }

        public void Delete(object model)
        {
            _sqLiteConnection.CreateTable(model.GetType());
            _sqLiteConnection.Delete(model);
        }

        public List<T> GetAll<T>() where T : new()
        {
            _sqLiteConnection.CreateTable<T>();
            return _sqLiteConnection.Table<T>().ToList();
        }
    }
}
