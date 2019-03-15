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
        private List<Customer> Customers { get; set; } = new List<Customer> { 
            new Customer() { Name = "Customer 1"},
            new Customer() { Name = "Customer 2"}
        };

        // GET: Customers
        public ActionResult Index()
        {            
            return View(Customers);
        }
    }
}