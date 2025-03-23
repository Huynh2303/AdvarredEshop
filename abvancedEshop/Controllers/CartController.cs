using abvancedEshop.Data;
using abvancedEshop.Infrastructure;
using abvancedEshop.Models;
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
        public IActionResult ProceedToCheckout()
        {
            // Lấy giỏ hàng từ Session
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();

            if (cart.line.Count == 0)
            {
                return RedirectToAction("Index", "Cart"); // Nếu giỏ hàng trống, quay lại giỏ hàng
            }

            // Tạo đơn hàng từ giỏ hàng
            Chechout checkout = new Chechout
            {
                ChechoutFirstName = "",
                ChechoutLastName = "",
                ChechoutEmail = "",
                ChechoutPhone = 0,
                AddressLine1 = "",
                AddressLine2 = "",
                ChechoutCity = "",
                ChechoutCountry = "",
                State = "",
                ZIpCode = 0,
                CreateAnAccount = false,
                ShipToDifferentAddress = false
            };

            _context.chechouts.Add(checkout);
            _context.SaveChanges();

            // Chuyển hướng đến trang Chechout với ID đơn hàng
            return RedirectToAction("Index", "Chechouts", new { id = checkout.CheckoutId });
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
