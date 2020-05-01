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
    public class CustomerCreateModel : PageModel
    {

        private readonly ICustomerRepository customerRepository;

        public CustomerCreateModel(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await customerRepository.Add(Customer);

            return RedirectToPage("./Index");
        }
    }
}
