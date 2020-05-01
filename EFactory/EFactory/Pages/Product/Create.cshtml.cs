using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLibrary.Data;
using DataLibrary.Models;
using DataLibrary.Repository;

namespace EFactory
{
    public class ProductCreateModel : PageModel
    {

        private readonly IProductRepository productRepository;

        public ProductCreateModel(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await productRepository.Add(Product);

            return RedirectToPage("./Index");
        }
    }
}
