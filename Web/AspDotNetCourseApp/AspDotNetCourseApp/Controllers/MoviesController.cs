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
			return View();
		
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