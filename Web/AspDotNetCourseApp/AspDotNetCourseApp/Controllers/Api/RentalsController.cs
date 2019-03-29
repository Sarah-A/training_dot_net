using AspDotNetCourseApp.Dtos;
using AspDotNetCourseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspDotNetCourseApp.Controllers.Api
{
    public class RentalsController : ApiController
    {
        ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);    
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult PostNewRentals(RentalDto rentalDto )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (rentalDto.MovieIds.Count == 0)
                return BadRequest("No Movies Ids in Request");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerId);
            if (customer == null)
                return BadRequest("Customer Id Not Found");

            var movies = _context.Movies
                                 .Where(m => (rentalDto.MovieIds.Contains(m.Id))).ToList();

            if (movies.Count != rentalDto.MovieIds.Count)
                return BadRequest("One or more movieIds are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest($"Movie {movie.Name} is unavailable");

                movie.NumberAvailable--;                

                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Today
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            // since we didn't create a single new resource and we just want to notify the user
            // that the action was successful, we don't return the Created but instead return Ok();
            return Ok();
            
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}