using abvancedEshop.Data;
using abvancedEshop.Infrastructure;
using abvancedEshop.Models;
using abvancedEshop.Models.SQLViewModel;
using Microsoft.AspNetCore.Mvc;

namespace abvancedEshop.Controllers
{
    public class CartController : Controller
    {
        public Cart? cart { get; set; }
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
             return View("Cart", HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart());
        }
       

        public IActionResult AddToCart(int ProductId)
        {
            Product? product = _context.Products.FirstOrDefault(p => p.ProductId == ProductId);
            if (product != null)
            {
                var cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
                cart.AddItem(product, 1);
                HttpContext.Session.Setjson("Cart", cart);
                return View("Cart", cart);
            }
            return NotFound();
        }    
        public IActionResult UpToCart(int ProductId)
        {
            Product? product = _context.Products.FirstOrDefault(p => p.ProductId == ProductId);
            if (product != null)
            {
                var cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
                cart.AddItem(product, -1);
                HttpContext.Session.Setjson("Cart", cart);
                return View("Cart", cart);
            }
            return NotFound();
        }     
        public IActionResult RemoveFromCart(int ProductId)
        {
            Product? product = _context.Products.FirstOrDefault(p => p.ProductId == ProductId);
            if (product != null)
            {
                var cart = HttpContext.Session.GetJson<Cart>("Cart");
                cart.RemoveLine(product);
                HttpContext.Session.Setjson("Cart", cart);
                return View("Cart", cart);
            }
            return NotFound();
        }

    }
}
