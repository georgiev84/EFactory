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
    public class OrderCreateModel : PageModel
    {
        private readonly DataLibrary.Data.EFactoryContext _context;
        private readonly IOrderRepository orderRepository;

        public OrderCreateModel(DataLibrary.Data.EFactoryContext context, IOrderRepository orderRepository)
        {
            _context = context;
            this.orderRepository = orderRepository;
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await orderRepository.Add(Order);

            return RedirectToPage("./Index");
        }
    }
}
