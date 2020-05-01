using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EFactoryContext context;

        public ProductRepository(EFactoryContext context)
        {
            this.context = context;
        }

        public async Task<Product> Add(Product product)
        {
            context.Product.Add(product);
            await context.SaveChangesAsync();
            return product;

 
        }

        public async Task Delete(int? id)
        {
            Product product = await GetProductAsync(id);
            if (product != null)
            {
                context.Product.Remove(product);
                context.SaveChanges();
            }
        }

        public async Task<Product> FindAsync(int? id)
        {
            Product product = await context.Product.FindAsync(id);
            return product;
        }

        public Product GetProduct(int? id)
        {
            return context.Product.Find(id);
        }

        public async Task<Product> GetProductAsync(int? id)
        {
            return await context.Product.FirstOrDefaultAsync(m => m.Id == id);
        }


        public async Task<Product> Update(Product changedProduct)
        {
            var product = context.Product.Attach(changedProduct);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return changedProduct;
        }

        public async Task<IList<Product>> GetAllProducts()
        {
            return await context.Product.ToListAsync();
        }

        public async Task CallListOfProductsAsync()
        {
            var searchTerm = "table";
            var products = await context.Product
                .FromSqlRaw("EXEC dbo.ProductsBySearchTerm @SearchTerm", new SqlParameter("@SearchTerm", searchTerm))
                .ToListAsync();
        }
    }
}
