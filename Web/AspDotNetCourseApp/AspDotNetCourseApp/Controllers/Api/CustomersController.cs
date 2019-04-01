using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AspDotNetCourseApp.Models;
using AspDotNetCourseApp.Dtos;
using System.Data.Entity;
using AutoMapper;

namespace AspDotNetCourseApp.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);    
        }


        // GET /api/customers
        public IHttpActionResult GetCustomers(string filterForRenting = null)
        {

            var customersInDb = _context.Customers
                                .Include(m => m.MembershipType);

            if (!String.IsNullOrWhiteSpace(filterForRenting))
            {
                customersInDb = customersInDb.Where(c => c.Name.Contains(filterForRenting));
            }

            var customersDtos = customersInDb.
                                    ToList()
                                    .Select(Mapper.Map<CustomerDto>);

            return Ok(customersDtos);
        }


        // GET /api/customers/{id}
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<CustomerDto>(customer));
        }

        // POST /api/customers - create a new customer
        // Note: since I called the function Post<object> - I could have removed the
        //       [HttpPost] decoration but I leave it anyway for future-proofing the code.
        [HttpPost]
        public IHttpActionResult PostCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);        
        }


        // PUT /api/customers/{id} - update customer id {id}
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = GetCustomerInDb(id);
            if (customerInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
            return Ok();
        }

        private Customer GetCustomerInDb(int id)
        {
            return _context.Customers.SingleOrDefault(c => c.Id == id);
        }

        // DELETE /api/customers/{id}
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
