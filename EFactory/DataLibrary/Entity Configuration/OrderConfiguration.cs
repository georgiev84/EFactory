using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace DataLibrary.Entity_Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder
               .HasOne(o => o.Customer)
               .WithMany(o=>o.Orders)
               .HasForeignKey(c => c.CustomerId);
        }
    }
}
