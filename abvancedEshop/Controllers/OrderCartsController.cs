using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using abvancedEshop.Data;
using abvancedEshop.Models;

namespace abvancedEshop.Controllers
{
    public class OrderCartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderCartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderCarts
        public  async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.orders.Include(o => o.Chechout);
            return View(await applicationDbContext.ToListAsync());
        }
        public  async Task<IActionResult>    order (OrderCart order)
        {     return Json("huynh");
            _context.Add(order);
            await _context.SaveChangesAsync();
            
        }
        // GET: OrderCarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderCart = await _context.orders
                .Include(o => o.Chechout)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderCart == null)
            {
                return NotFound();
            }

            return View(orderCart);
        }

        // GET: OrderCarts/Create
        public IActionResult Create()
        {
            ViewData["ChechoutId"] = new SelectList(_context.chechouts, "CheckoutId", "AddressLine1");
            return View();
        }

        // POST: OrderCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ChechoutId,OrderDate,TotalAmount")] OrderCart orderCart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderCart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChechoutId"] = new SelectList(_context.chechouts, "CheckoutId", "AddressLine1", orderCart.ChechoutId);
            return View(orderCart);
        }

        // GET: OrderCarts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderCart = await _context.orders.FindAsync(id);
            if (orderCart == null)
            {
                return NotFound();
            }
            ViewData["ChechoutId"] = new SelectList(_context.chechouts, "CheckoutId", "AddressLine1", orderCart.ChechoutId);
            return View(orderCart);
        }

        // POST: OrderCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,ChechoutId,OrderDate,TotalAmount")] OrderCart orderCart)
        {
            if (id != orderCart.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderCartExists(orderCart.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChechoutId"] = new SelectList(_context.chechouts, "CheckoutId", "AddressLine1", orderCart.ChechoutId);
            return View(orderCart);
        }

        // GET: OrderCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderCart = await _context.orders
                .Include(o => o.Chechout)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderCart == null)
            {
                return NotFound();
            }

            return View(orderCart);
        }

        // POST: OrderCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderCart = await _context.orders.FindAsync(id);
            if (orderCart != null)
            {
                _context.orders.Remove(orderCart);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderCartExists(int id)
        {
            return _context.orders.Any(e => e.OrderId == id);
        }
    }
}
