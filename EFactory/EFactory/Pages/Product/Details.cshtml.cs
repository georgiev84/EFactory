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
    public class ProductDetailsModel : PageModel
    {
        
        private readonly IProductRepository productRepository;

        public ProductDetailsModel(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await productRepository.GetProductAsync(id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
