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
    public class OrderDeleteModel : PageModel
    {

        private readonly IOrderRepository orderRepository;

        public OrderDeleteModel(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await orderRepository.GetAsync(id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await orderRepository.Delete(id);

            return RedirectToPage("./Index");
        }
    }
}
