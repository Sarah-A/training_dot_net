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

            // Note: we use Single and not SingleOrDefault here since the user will pick up the 
            // customer from a list so we don't expect this to fail. Exception will be thrown if 
            // it does fail which is the correct way to handle unexpected fails.
            var customer = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);
            
            var movies = _context.Movies
                                 .Where(m => rentalDto.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {               
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