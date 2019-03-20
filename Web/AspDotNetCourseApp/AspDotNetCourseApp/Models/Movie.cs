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
        [StringLength(255, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime? AddedToDb { get; set; }
        
        [Required]
        [Display(Name="Genre")]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }

        [Required]        
        [Display(Name="Number In Stock")]
        [Range(1,50)]
        public byte NumberInStock { get; set; }
    }
}