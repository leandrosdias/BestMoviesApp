using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestMoviesApp.Models
{
    class Config
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Language { get; set; }    
    }
}
