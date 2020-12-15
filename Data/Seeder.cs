using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Data.Entities;

namespace WebApplication2.Data
{
    public class Seeder
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IWebHostEnvironment _hosting;
        private readonly Microsoft.AspNetCore.Identity.UserManager<StoreUser> _userManager;

        public Seeder(ApplicationDbContext ctx, IWebHostEnvironment hosting, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();
            StoreUser user = await _userManager.FindByEmailAsync("ahmet@gmail.com");
            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Ahmet",
                    LastName = "Tach",
                    Email = "ahmet@gmail.com",
                    UserName = "ahmet@gmail.com"
                };
                var result = await _userManager.CreateAsync(user, "P@sswo0rd!");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder...");
                }
            }

            if (!_ctx.Products.Any())
            {
                // create sample data if no data in database
                var filePath = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filePath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);


                var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
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
                _ctx.SaveChanges();
            }
        }
    }
}
