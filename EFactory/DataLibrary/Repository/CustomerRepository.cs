using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly EFactoryContext context;

        public CustomerRepository(EFactoryContext context)
        {
            this.context = context;
        }

        public async Task<Customer> Add(Customer customer)
        {
            context.Customer.Add(customer);
            await context.SaveChangesAsync();
            return customer;
        }

        public async Task Delete(int? id)
        {
            Customer customer = await GetAsync(id);
            if (customer != null)
            {
                context.Customer.Remove(customer);
                context.SaveChanges();
            }
        }

        public async Task<Customer> FindAsync(int? id)
        {
            Customer customer = await context.Customer.FindAsync(id);
            return customer;
        }

        public async Task<IList<Customer>> GetAllAsync()
        {
            return await context.Customer.ToListAsync();
        }

        public async Task<Customer> GetAsync(int? id)
        {
            return await context.Customer.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> UpdateAsync(Customer changedProduct)
        {
            var customer = context.Customer.Attach(changedProduct);
            customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return changedProduct;
        }
    }
}
