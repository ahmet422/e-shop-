using System.Collections.Generic;
using WebApplication2.Data.Entities;

namespace WebApplication2.Data
{
    public interface IApplicationRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCathegory(string category);
        bool SaveAll();
        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);
        Order GetOrderById(string username, int id);
        void AddEntity(object model);
        void AddOrder(Order newOrder);
    }
}