using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLibrary.Data;
using DataLibrary.Models;

namespace EFactory
{
    public class OrderDetailsDetailsModel : PageModel
    {
        private readonly DataLibrary.Data.EFactoryContext _context;

        public OrderDetailsDetailsModel(DataLibrary.Data.EFactoryContext context)
        {
            _context = context;
        }

        public OrderDetails OrderDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderDetails = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product).FirstOrDefaultAsync(m => m.Id == id);

            if (OrderDetails == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
