using AspDotNetCoreFromScratch.Data.Entities;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetCoreFromScratch.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext _context;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public DutchSeeder(DutchContext context, 
                            IHostingEnvironment hosting,
                            UserManager<StoreUser> userManager)
        {
            _context = context;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            // Make sure that the database exist before starting to seed it:
            _context.Database.EnsureCreated();

            StoreUser user = await _userManager.FindByEmailAsync("user@example.com");
            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "User",
                    LastName = "Exampler",
                    Email = "user@example.com",
                    UserName = "user@example.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");

                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create default user in Seeder");
                }
            }


            if (!_context.Products.Any())
            {
                // we don't have any products - create sample data.
                // This method can also be used to create static data (e.g. lookup tables) 
                // instead of overriding the OnModelCreating method.
                
                // Create products:
                var filePath = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filePath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

                _context.Products.AddRange(products);

                // Complete the orders creation.
                // this demonstrate how to combine the two seeding methods - 
                // the order was created by overriding the OnModelCreating and the 
                // order.Items list was created using the custom seeding class:
                var order = _context.Orders.SingleOrDefault(o => o.Id == 1);
                if (order != null)
                {
                    order.User = user;
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price

                        }
                    };
                }
                
                _context.SaveChanges();
            }

        }
    }
}
