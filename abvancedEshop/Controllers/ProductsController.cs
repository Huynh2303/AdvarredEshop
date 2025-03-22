using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using abvancedEshop.Data;
using abvancedEshop.Models;
using abvancedEshop.Models.ViewModel;
using Microsoft.VisualStudio.Web.CodeGeneration.Templating;

namespace abvancedEshop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        int pageSize = 3;
        // GET: Products
        public async Task<IActionResult> Index(int productPage = 1)
        {
            return View(
                         new ProductListViewModel
                         {
                             Products = _context.Products  
                               .Skip((productPage-1)*pageSize)
                               .Take(pageSize),

                               PagingInfor = new PagingInfor
                               {
                                   ItemPerPage= pageSize,
                                   CurrenPage= productPage,
                                   TotalItem = _context.Products.Count()
                               }
                                
                         }
                
                
                
                );
        }                 public async Task<IActionResult> Search( string Searchstring ,int productPage = 1 )
        {
            return View(  "Index",
                         new ProductListViewModel
                         {
                             Products = _context.Products .Where(p=>p.ProductName.Contains(Searchstring)) 
                               .Skip((productPage-1)*pageSize)
                               .Take(pageSize),

                               PagingInfor = new PagingInfor
                               {
                                   ItemPerPage= pageSize,
                                   CurrenPage= productPage,
                                   TotalItem = _context.Products.Count()
                               }
                                
                         }
                
                
                
                );
        }
        public async Task<IActionResult> ProductsBycat(int categoryid, IEnumerable<Product> products)
        {
            var products1 = await _context.Products
            .Where(p => p.CategoryId == categoryid)
            .Include(p => p.Category)
            .Include(p => p.Color)
            .Include(p => p.Size)
            .ToListAsync();
            Console.WriteLine($"Category ID: {categoryid}, Products found: {products1.Count}"); // Debug
            var viewmodel = new ProductListViewModel {


                Products = products1

            }; 
            if (!products.Any())
            {
                ViewBag.Message = "Không có sản phẩm nào trong danh mục này.";
            }
            return View("Index", viewmodel);
        }


        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Color)
                .Include(p => p.Size)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["ColorId"] = new SelectList(_context.Colors, "ColorId", "ColorId");
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeId");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductDescription,CategoryId,ProductPrice,ProductDiscount,ProductPhoto,SizeId,ColorId,IsTrandy,IsArrived")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "ColorId", "ColorId", product.ColorId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeId", product.SizeId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "ColorId", "ColorId", product.ColorId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeId", product.SizeId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductDescription,CategoryId,ProductPrice,ProductDiscount,ProductPhoto,SizeId,ColorId,IsTrandy,IsArrived")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "ColorId", "ColorId", product.ColorId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeId", product.SizeId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Color)
                .Include(p => p.Size)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
