using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DataLibrary.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> GetAsync(int? id);
        Task<IList<Customer>> GetAllAsync();
        Task<Customer> Add(Customer customer);
        Task<Customer> UpdateAsync(Customer changedOrder);
        Task Delete(int? id);
        Task<Customer> FindAsync(int? id);
    }
}
