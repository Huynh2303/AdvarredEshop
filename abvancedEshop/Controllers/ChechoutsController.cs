using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using abvancedEshop.Data;
using abvancedEshop.Models;
using abvancedEshop.Infrastructure;

namespace abvancedEshop.Controllers
{
    public class ChechoutsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChechoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chechouts
        public async Task<IActionResult> Index()
        {
            var checkout = await _context.chechouts.OrderByDescending(c => c.CheckoutId).FirstOrDefaultAsync();

            if (checkout == null)
            {
                return RedirectToAction("Index", "Cart"); // Nếu không có đơn hàng nào, quay lại giỏ hàng
            }
           
            return View(checkout);
        }


        // GET: Chechouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chechout = await _context.chechouts
                .FirstOrDefaultAsync(m => m.CheckoutId == id);
            if (chechout == null)
            {
                return NotFound();
            }

            return View(chechout);
        }

        // GET: Chechouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chechouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckoutId,ChechoutFirstName,ChechoutLastName,ChechoutEmail,ChechoutPhone,AddressLine1,AddressLine2,ChechoutCity,ChechoutCountry,State,ZIpCode,CreateAnAccount,ShipToDifferentAddress")] Chechout chechout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chechout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chechout);
        }

        // GET: Chechouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chechout = await _context.chechouts.FindAsync(id);
            if (chechout == null)
            {
                return NotFound();
            }
            return View(chechout);
        }

        // POST: Chechouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckoutId,ChechoutFirstName,ChechoutLastName,ChechoutEmail,ChechoutPhone,AddressLine1,AddressLine2,ChechoutCity,ChechoutCountry,State,ZIpCode,CreateAnAccount,ShipToDifferentAddress")] Chechout chechout)
        {
            if (id != chechout.CheckoutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chechout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChechoutExists(chechout.CheckoutId))
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
            return View(chechout);
        }

        // GET: Chechouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chechout = await _context.chechouts
                .FirstOrDefaultAsync(m => m.CheckoutId == id);
            if (chechout == null)
            {
                return NotFound();
            }

            return View(chechout);
        }

        // POST: Chechouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chechout = await _context.chechouts.FindAsync(id);
            if (chechout != null)
            {
                _context.chechouts.Remove(chechout);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChechoutExists(int id)
        {
            return _context.chechouts.Any(e => e.CheckoutId == id);
        }
    }
}
