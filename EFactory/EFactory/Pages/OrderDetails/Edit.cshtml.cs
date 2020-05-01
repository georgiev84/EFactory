using System;
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
    public class OrderDetailsEditModel : PageModel
    {
        private readonly IOrderDetailsRepository orderDetailsRepository;
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;
        
        public OrderDetailsEditModel(IOrderDetailsRepository orderDetailsRepository, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            this.orderDetailsRepository = orderDetailsRepository;
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
        }

        [BindProperty]
        public OrderDetails OrderDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderDetails = await orderDetailsRepository.FindAsync(id);

            if (OrderDetails == null)
            {
                return NotFound();
            }

            ViewData["OrderId"] = new SelectList(await orderRepository.GetAllAsync(), "Id", "Id");
            ViewData["ProductId"] = new SelectList(await productRepository.GetAllProducts(), "Id", "Id");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            OrderDetails.TotalProductPrice = OrderDetails.Price * OrderDetails.Quantity;
            await orderDetailsRepository.UpdateAsync(OrderDetails);

            return RedirectToPage("./Index");
        }

    }
}
