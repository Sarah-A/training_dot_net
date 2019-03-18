using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspDotNetCourseApp.Models;

namespace AspDotNetCourseApp.Controllers
{
    public class CustomersController : Controller
    {

        private List<Customer> GetCustomers()
        {
            return new List<Customer> {
            new Customer() { Name = "Customer 1", Id = 1},
            new Customer() { Name = "Customer 2", Id = 2}
            };
        }

        // GET: Customers
        public ActionResult Index()
        {            
            return View(GetCustomers());
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return Content($"Customer id ${id} not found!");
            }
            else
            {
                return View(customer);
            }
        }
    }
}