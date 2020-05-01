using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repository
{
    public interface IOrderRepository
    {
        Task QueryViewAsync();
        Task<Order> GetAsync(int? id);
        Task<IList<Order>> GetAllAsync();
        Task<Order> Add(Order order);
        Task<Order> UpdateAsync(Order changedOrder);
        Task Delete(int? id);
        Task<Order> FindAsync(int? id);
    }
}
