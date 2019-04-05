using AspDotNetCoreFromScratch.Data;
using AspDotNetCoreFromScratch.Services;
using AspDotNetCoreFromScratch.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetCoreFromScratch.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly DutchContext _context;

        public AppController(IMailService mailService, DutchContext context)
        {
            _mailService = mailService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Note: because we use HTML Tags on the navbar in _Layout.cshtml - when we set the path in the action inside the controller,
        // the link automatically point to the right place, without having to change the cshtml. 
        // in this case, the 'Contact' link will point to <url>/Contact instead of the /App/Contact which is the default.
        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("Contact")]
        public IActionResult Contact(ContactViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage(viewModel.Email, viewModel.Subject, viewModel.Message);
                ViewBag.UserMessage = "Message Sent!";
                ModelState.Clear();
                
            }
            return View();
        }
                

        public IActionResult About()
        {
            return View();
        }

        public IActionResult TestUnhandledException()
        {
            throw new Exception("I threw this... HaHaHa");
        }

        public IActionResult Shop()
        {
            var products = from p in _context.Products
                           orderby p.Category
                           select p;

            return View(products.ToList());
        }
        
    }
}
