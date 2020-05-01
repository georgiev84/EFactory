using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Repository
{
    public interface IProductRepository
    {
        Product GetProduct(int? id);
        Task<Product> GetProductAsync(int? id);
        Task<IList<Product>> GetAllProducts();
        Task<Product> Add(Product product);
        Task<Product> Update(Product changedProduct);
        Task Delete(int? id);
        Task<Product> FindAsync(int? id);
        Task CallListOfProductsAsync();
    }
}
