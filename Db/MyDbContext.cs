using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopLinux.Models;

namespace ShopLinux.Db
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
            
        }
       
        public DbSet<Product> Products { get; set; }

    }
}
