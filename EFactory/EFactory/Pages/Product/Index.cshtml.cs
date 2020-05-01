using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLibrary.Data;
using DataLibrary.Models;
using DataLibrary.Repository;

namespace EFactory
{
    public class IndexProductModel : PageModel
    {

        private readonly IProductRepository productRepository;

        public IndexProductModel(IProductRepository productRepository)
        {

            this.productRepository = productRepository;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {

            Product = await productRepository.GetAllProducts();

            // TASK 6
            //await productRepository.CallListOfProductsAsync();
        }
    }
}
