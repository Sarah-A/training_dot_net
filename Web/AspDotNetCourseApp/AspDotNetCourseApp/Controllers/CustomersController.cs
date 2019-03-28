using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AspDotNetCourseApp.Models;
using AspDotNetCourseApp.ViewModels;


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
            // Using Lazy Loading - will send one query to get all customers and then additional up to N queries to get all 
            // MembershipTypes refered to be these customers => might lead to the N+1 issue, where N is the number of MembershipTypes:
            // When testing with Glimpse - for 8 customers with 3 membership types - sent 4 queries (with 2 database access) and took a total of 54.2 ms
            var customers = _context.Customers.ToList();

            // Using Eager Loading - will get the memebership type as part of the original query so we'll have less queries: 
            // When testing with Glimpe - for 8 customers with 3 membership types - sent one query with INNER JOIN which was extremely slow and took 57.84 ms
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
            
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

        public ActionResult Edit(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes
                };

                return View("CustomerForm", viewModel);
            }
        }

        public ActionResult CustomerForm()
        {
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };       

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                return RedirectToAction("Index", "Customers");
            }
            else
            {
                return RedirectToAction("CustomerForm", "Customers");
            }
        }

        [HttpPost]
        public ActionResult Update(Customer customer)
        {            
            var customerInDb = GetCustomers().Single(c => c.Id == customer.Id);

            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = GetCustomers().Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");

        }
    }
}