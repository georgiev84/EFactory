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
    public class OrderDetailsCreateModel : PageModel
    {
        private readonly DataLibrary.Data.EFactoryContext _context;
        private readonly IOrderDetailsRepository orderDetailsRepository;
       
        private static int parameterId;
        public OrderDetailsCreateModel(DataLibrary.Data.EFactoryContext context, IOrderDetailsRepository orderDetailsRepository)
        {
            _context = context;
            this.orderDetailsRepository = orderDetailsRepository;
        }

        public IActionResult OnGet(int id)
        {
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            ViewData["OrderNumber"] = id;

            parameterId = id;
            return Page();
        }

        [BindProperty]
        public OrderDetails OrderDetails { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            OrderDetails.TotalProductPrice = OrderDetails.Price * OrderDetails.Quantity;

            await orderDetailsRepository.Add(OrderDetails);

            return RedirectToPage("./Index", new { id = parameterId });
        }
    }
}
