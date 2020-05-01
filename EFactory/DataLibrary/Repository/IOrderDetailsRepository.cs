using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Repository
{
    public interface IOrderDetailsRepository
    {
        Task<OrderDetails> GetAsync(int? id);
        Task<IList<OrderDetails>> GetAllAsync(int? id);
        Task<OrderDetails> Add(OrderDetails orderDetails);
        Task<OrderDetails> UpdateAsync(OrderDetails changedOrderDetails);
        Task Delete(int? id);
        Task<OrderDetails> FindAsync(int? id);
    }
}
