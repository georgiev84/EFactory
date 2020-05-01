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
    public class CustomerIndexModel : PageModel
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerIndexModel(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await customerRepository.GetAllAsync();
        }
    }
}
