using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EFactoryContext context;

        public OrderRepository(EFactoryContext context)
        {
            this.context = context;
        }

        public async Task<Order> Add(Order order)
        {
            context.Order.Add(order);
            await context.SaveChangesAsync();
            return order;
        }

        public async Task Delete(int? id)
        {
            Order order = await GetAsync(id);
            if (order != null)
            {
                context.Order.Remove(order);
                context.SaveChanges();
            }
        }

        public async Task<Order> FindAsync(int? id)
        {
            Order order = await context.Order.FindAsync(id);
            return order;
        }

        public async Task<IList<Order>> GetAllAsync()
        {
            return await context.Order.Include(o => o.Customer).ToListAsync();
        }

        public async Task<Order> GetAsync(int? id)
        {
            return await context.Order.FirstOrDefaultAsync(o => o.Id == id);
        }


        public async Task<Order> UpdateAsync(Order changedOrder)
        {
            var order = context.Order.Attach(changedOrder);
            order.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return changedOrder;
        }

        // TASK 5
        public async Task QueryViewAsync()
        {
            var reportItems = await context.Order.ToListAsync();

            DateTime now = DateTime.Now;
            var firstDateOfMonth = new DateTime(now.Year, now.Month, 1);

            var filteredReportItems = await context
                .Order
                .Where(pr => pr.Date >= firstDateOfMonth.Date)
                .ToListAsync();
        }
    }
}
