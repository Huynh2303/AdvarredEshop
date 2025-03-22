using abvancedEshop.Data;
using abvancedEshop.Infrastructure;
using abvancedEshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace abvancedEshop.Components
{
    public class CartWidget   : ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
            return View(HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart());
        }
    }
}
