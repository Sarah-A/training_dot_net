using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspDotNetCourseApp.Models;
using System.Data.Entity;


namespace AspDotNetCourseApp.Controllers
{
    public class CustomersController : Controller
    {
        // in order to be able to query the database in the CustomersController, we need
        // to connect it to the applicaiton database using a private field:
        // We also need to initialize it in the constructor and to override Controller.Dispose
        // function to dispose it:
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



        private List<Customer> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType).ToList();           
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

        public ActionResult New()
        {
            return View();
        }
    }
}