using Microsoft.EntityFrameworkCore;
using Models;
using TestApplication.Models;

namespace TestApplication.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}
        public DbSet<Product> Product {get; set;}
        public DbSet<Product_description> Product_Description {get; set;}
        public DbSet<Customers> Customers {get; set;}
        public DbSet<Customers_Description> customers_Description {get; set;}
        public DbSet<Shop> Shop {get; set;}
    }
}