using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLibrary.Data;
using DataLibrary.Models;
using DataLibrary.Repository;
using Microsoft.AspNetCore.Authorization;

namespace EFactoryMVC.Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        private readonly EFactoryContext _context;
        private readonly IOrderDetailsRepository orderDetailsRepository;

        public OrderDetailsController(EFactoryContext context, IOrderDetailsRepository orderDetailsRepository)
        {
            _context = context;
            this.orderDetailsRepository = orderDetailsRepository;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["OrderNumber"] = id;

            return View(await orderDetailsRepository.GetAllAsync(id));

        }


        // GET: OrderDetails/Create
        public IActionResult Create(int id)
        {
            var orderDetails = new OrderDetails
            {
                OrderId = id
            };
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name");
            return View(orderDetails);
        }

        // POST: OrderDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ProductId,Quantity,Price,TotalProductPrice")] OrderDetails orderDetails)
        {
            if (ModelState.IsValid)
            {
                orderDetails.TotalProductPrice = orderDetails.Price * orderDetails.Quantity;
                await orderDetailsRepository.Add(orderDetails);

                return RedirectToAction("Details", new { id = orderDetails.OrderId });
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", orderDetails.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", orderDetails.ProductId);
            return View(orderDetails);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await orderDetailsRepository.FindAsync(id);

            if (orderDetails == null)
            {
                return NotFound();
            }

            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name");
            return View(orderDetails);
        }

        // POST: OrderDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,ProductId,Quantity,Price")] OrderDetails orderDetails)
        {
            if (id != orderDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    orderDetails.TotalProductPrice = orderDetails.Price * orderDetails.Quantity;
                    await orderDetailsRepository.UpdateAsync(orderDetails);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailsExists(orderDetails.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = orderDetails.OrderId });
            }

            return View(orderDetails);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await orderDetailsRepository.GetAsync(id);

            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetails = await orderDetailsRepository.FindAsync(id);
            await orderDetailsRepository.Delete(id);

            return RedirectToAction("Details", new { id = orderDetails.OrderId });
        }

        private bool OrderDetailsExists(int id)
        {
            return _context.OrderDetails.Any(e => e.Id == id);
        }
    }
}
