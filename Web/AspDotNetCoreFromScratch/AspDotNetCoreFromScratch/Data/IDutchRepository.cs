using System.Collections.Generic;
using DutchTreat.Data.Entities;

namespace AspDotNetCoreFromScratch.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetAllOrdersByUser(string userName, bool includeItems);
        Order GetOrderById(string userName, int id);
        void AddEntity(Order model);
        void AddOrder(Order model);


    }
}