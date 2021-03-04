using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopLinux.Db;
using ShopLinux.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopLinux.Repositories
{
    public class ProductRepository
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;
        DbContextOptionsBuilder<MyDbContext> _optionsBuilder;
        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            _connectionString = _configuration!["myconn"];
            _optionsBuilder.UseSqlServer(_connectionString);
        }


        public void AddProduct(Product product)
        {
            try
            {
                using (var context = new MyDbContext(_optionsBuilder.Options))
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public List<Product> GetProducts()
        {
            using (var context = new MyDbContext(_optionsBuilder.Options))
            {
                return context.Products.ToList();
            }
        }

        public void DeleteProduct(Product product)
        {
            using (var context = new MyDbContext(_optionsBuilder.Options))
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
