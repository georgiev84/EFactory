
using Microsoft.EntityFrameworkCore;
using DataLibrary.Entity_Configuration;
using DataLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DataLibrary.Data
{
    public class EFactoryContext : IdentityDbContext<WebUser, IdentityRole, string>
    {
        
        public EFactoryContext (DbContextOptions<EFactoryContext> options)
            : base(options)
        {
        }

        public EFactoryContext()
        {
           
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
            modelBuilder.Entity<Product>().HasIndex(p => p.Name);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
