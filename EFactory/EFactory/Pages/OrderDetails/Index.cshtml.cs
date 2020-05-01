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
    public class OrderDetailsIndexModel : PageModel
    {
      
       private readonly IOrderDetailsRepository orderDetailsRepository;
        public OrderDetailsIndexModel( IOrderDetailsRepository orderDetailsRepository)
        {
               this.orderDetailsRepository = orderDetailsRepository;
        }

        public IList<OrderDetails> OrderDetails { get;set; }

        public async Task OnGetAsync(int id)
        {
            ViewData["OrderNumber"] = id;

            OrderDetails = await orderDetailsRepository.GetAllAsync(id);
        }
    }
}
