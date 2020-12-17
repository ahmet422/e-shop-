using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Data.Entities;

namespace WebApplication2.Data
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly ILogger _logger;
        public ApplicationRepository(ApplicationDbContext ctx, ILogger<ApplicationRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public void AddOrder(Order newOrder)
        {
            foreach (var item in newOrder.Items) 
            {
                item.Product = _ctx.Products.Find(item.Product.Id);
            }
            AddEntity(newOrder);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToList();
            }
            else 
            {
                return _ctx.Orders
                .ToList();
            }

        }

        public IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders
                .Where(o => o.User.UserName == username)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToList();
            }
            else
            {
                return _ctx.Orders
                .Where(o => o.User.UserName == username)
                .ToList();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try 
            {
                _logger.LogInformation("GetAllProducts was called");
                return _ctx.Products.OrderBy(p => p.Title).ToList();
            }

            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }

        }

        public Order GetOrderById(string username, int id)
        {
            return _ctx.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.Id == id && o.User.UserName == username)
                .FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByCathegory(string category)
        {
            try
            {
                _logger.LogInformation("GetProductsByCathegory was called");
                return _ctx.Products.Where(p => p.Category == category).ToList();
            }

            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
           
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
