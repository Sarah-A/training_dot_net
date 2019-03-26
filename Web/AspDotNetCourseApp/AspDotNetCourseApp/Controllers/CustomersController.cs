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
            return View();
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