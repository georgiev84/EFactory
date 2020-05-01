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
    public class CustomerDetailsModel : PageModel
    {

        private readonly ICustomerRepository customerRepository;
        public CustomerDetailsModel(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await customerRepository.GetAsync(id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
