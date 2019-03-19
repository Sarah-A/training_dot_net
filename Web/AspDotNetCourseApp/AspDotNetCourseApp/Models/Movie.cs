using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AspDotNetCourseApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime AddedToDb { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public byte NumberInStock { get; set; }
    }
}