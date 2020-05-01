using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Repository
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly EFactoryContext context;
        
        public OrderDetailsRepository(EFactoryContext context)
        {
            this.context = context;
        }

        public async Task<OrderDetails> Add(OrderDetails orderDetails)
        {
            context.OrderDetails.Add(orderDetails);
            await context.SaveChangesAsync();
            return orderDetails;
        }

        public async Task Delete(int? id)
        {
            OrderDetails orderDetails = await GetAsync(id);
            if (orderDetails != null)
            {
                context.OrderDetails.Remove(orderDetails);
                context.SaveChanges();
            }
        }

        public async Task<OrderDetails> FindAsync(int? id)
        {
            return await context.OrderDetails
            .Include(o => o.Order)
            .Include(o => o.Product).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IList<OrderDetails>> GetAllAsync(int? id)
        {
            return await context.OrderDetails
                 .Include(o => o.Order)
                 .Include(o => o.Product)
                 .Where(o => o.OrderId == id)
                 .ToListAsync();
        }

        public async Task<OrderDetails> GetAsync(int? id)
        {
            return await context.OrderDetails.FirstOrDefaultAsync(od => od.Id == id);
        }

        public async Task<OrderDetails> UpdateAsync(OrderDetails changedOrderDetails)
        {
            var orderDetails = context.OrderDetails.Attach(changedOrderDetails);
            orderDetails.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return changedOrderDetails;
        }
    }
}
