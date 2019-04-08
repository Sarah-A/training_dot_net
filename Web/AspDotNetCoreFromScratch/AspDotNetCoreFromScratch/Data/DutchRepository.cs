using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetCoreFromScratch.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _context;
        private readonly ILogger<DutchRepository> _logger;

        public DutchRepository(DutchContext context, ILogger<DutchRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Product> GetProducts()
        {
            try
            {
                return _context.Products
                               .OrderBy(p => p.Title)
                               .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            try
            {
                return _context.Products
                               .Where(p => p.Category == category)
                               .OrderBy(p => p.Title)
                               .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return null;
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            try
            {
                return _context.Orders
                        .Include(o => o.Items)
                        .ThenInclude(i => i.Product)
                        .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get orders: {ex}");
                return null;                
            }
        }

        public bool SaveAll()
        {
            return (_context.SaveChanges() > 0);
        }

        public Order GetOrderById(int id)
        {
            try
            { 
                return _context.Orders
                                .Include(o => o.Items)
                                .ThenInclude(i => i.Product)
                                .Where(o => o.Id == id)
                                .FirstOrDefault();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get order: {ex}");
                return null;
            }
        }

        public void AddEntity(Order model)
        {
            try
            {
                _context.Add(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add new model: {ex}");
            }
        }
    }
}
