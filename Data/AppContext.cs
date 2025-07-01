using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using retail_backend.Data.Entities;

namespace retail_backend.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
        : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<TelegramUser> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ConfKeys> Constants { get; set; }
    }
}