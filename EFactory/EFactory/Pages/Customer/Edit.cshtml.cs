﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLibrary.Data;
using DataLibrary.Models;
using DataLibrary.Repository;

namespace EFactory
{
    public class CustomerEditModel : PageModel
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerEditModel(DataLibrary.Data.EFactoryContext context, ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [BindProperty]
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await customerRepository.UpdateAsync(Customer);

            return RedirectToPage("./Index");
        }
    }
}
