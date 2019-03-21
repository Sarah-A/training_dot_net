using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspDotNetCourseApp.Models;
using AspDotNetCourseApp.ViewModels;
using System.Data.Entity;

namespace AspDotNetCourseApp.Controllers
{
   
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        private List<Movie> GetMovies()
        {
            return _context.Movies.Include(m => m.Genre).ToList();
        }

        // GET: Movies
        public ActionResult Index()
        {
            return View(GetMovies());          
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
               

        [Route("movies/releases/{year:regex(\\d{4}):range(1900,2019)}/{month:regex(\\d{1-2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {            
            return Content($"year: {year} , month: {month}");
        }

        [Route("movies/details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return Content($"Movie ID: ${id} not found!");
            }
            else
            {
                return View(movie);
            }
        }

        public ActionResult MovieForm()
        {
            var viewModel = new MovieFormViewModel()
            {                
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres
                };
                return View("MovieForm", viewModel);
            }
            
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = GetMovies().Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == id);
            if(movie == null)
            {
                return Content($"Movie: {id} Could not be found!!");
            }
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres
            };
            return View("MovieForm", viewModel);
        }





    }
}