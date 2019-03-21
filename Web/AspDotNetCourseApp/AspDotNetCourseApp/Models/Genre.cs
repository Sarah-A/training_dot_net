using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspDotNetCourseApp.Models
{
    public enum GenreTypeIds : byte
    {
        Unknown = 0,
        Comedy,
        Action,
        Family,
        Romance
    };

    public class Genre
    {
        public GenreTypeIds Id { get; set; }
        public string Name { get; set; }
    }
}