using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspDotNetCourseApp.Models;
using AspDotNetCourseApp.ViewModels;

namespace AspDotNetCourseApp.Controllers
{
   
    public class MoviesController : Controller
    {
        private List<Movie> Movies { set; get; } = new List<Movie> {
                new Movie() {Name = "Shrek 1"},
                new Movie() {Name = "Shrek 2"},
                new Movie() {Name = "Shrek 3"},
        };

        // GET: Movies
        public ActionResult Index()
        {
            return View(Movies);          
        }

        // Example for using View to send the model (Movie) to the view:
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            return View(movie);            
        }

        // Example of using ViewData to send data (partial or calculated) to the view:
        public ActionResult RandomAsViewData()
        {
            var movie = new Movie() { Name = "Shrek -1!" };
            ViewData["Movie"] = movie;
            return View();
        }

        // Example of using ViewBag  - a newer way than ViewData to send data (partial or calculated) to the view:
        public ActionResult RandomAsViewBag()
        {
            var movie = new Movie() { Name = "Shrek 2!" };
            ViewBag.MovieName = movie.Name;
            return View();
        }

        // Example of using ViewModel  - the most recommended and type-safe way:
        public ActionResult RandomAsViewModel()
        {
            var moviesRandom = new MoviesRandomViewModel()
            {
                Movie = new Movie() { Name = "Shrek - the best!! " },
                Customers = new List<Customer>{
                    new Customer() { Name = "Customer 1" },
                    new Customer() { Name = "Customer 2" }
                }
            };

            return View(moviesRandom);
        }

        public ActionResult Edit(int id)
        {
            return Content($"id={id}");
        }

        [Route("movies/releases/{year:regex(\\d{4}):range(1900,2019)}/{month:regex(\\d{1-2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {            
            return Content($"year: {year} , month: {month}");
        }


        
        

    }
}