using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Entity_Configuration
{
    class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            //builder
            //.HasKey(od => new { od.OrderId, od.ProductId });

            builder
                .HasKey(od => od.Id);

            builder
                .HasOne(p => p.Product)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(p => p.ProductId);

            builder
                .HasOne(o => o.Order)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(o => o.OrderId);

           
        }
    }
}
