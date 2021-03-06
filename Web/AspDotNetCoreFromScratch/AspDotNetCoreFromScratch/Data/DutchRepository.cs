﻿using DutchTreat.Data.Entities;
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

        public IEnumerable<Product> GetAllProducts()
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

        public IEnumerable<Order> GetAllOrdersByUser(string userName, bool includeItems)
        {
            try
            {
                if (includeItems)
                {
                    return _context.Orders
                        .Where(o => o.User.UserName == userName)                        
                        .Include(o => o.Items)
                        .ThenInclude(i => i.Product)
                        .ToList();
                }
                else
                {
                    return _context.Orders
                        .Where(o => o.User.UserName == userName)
                        .ToList();
                }
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

        public Order GetOrderById(string userName, int id)
        {
            try
            { 
                return _context.Orders
                                .Include(o => o.Items)
                                .ThenInclude(i => i.Product)
                                .Where(o => o.Id == id && o.User.UserName == userName)
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

        public void AddOrder(Order newOrder)
        {            
                        // replace all items in the new order with the correct items from the database:
			// otherwise, we will receive an exception trying to insert duplicate Prodcuts.
            foreach (var item in newOrder.Items) {
                item.Product = _context.Products.Find(item.Product.Id);
            }

            AddEntity(newOrder);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            try
            {
                if (includeItems)
                {
                    return _context.Orders
                        .Include(o => o.Items)
                        .ThenInclude(i => i.Product)
                        .ToList();
                }
                else
                {
                    return _context.Orders.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get orders: {ex}");
                return null;
            }
        }

        
    }
}
