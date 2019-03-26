using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspDotNetCourseApp.Models;

namespace AspDotNetCourseApp.Dtos
{
    public class GenreDto
    {
        public GenreTypeIds Id { get; set; }
        public string Name { get; set; }
    }
}