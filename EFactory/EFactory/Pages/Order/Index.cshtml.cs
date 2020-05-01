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
    public class OrderIndexModel : PageModel
    {
        private readonly IOrderRepository orderRepository;

        public OrderIndexModel(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {

            Order = await orderRepository.GetAllAsync();

            // TASK 5 Call the view
            //await orderRepository.QueryViewAsync();
        }

    }
}
