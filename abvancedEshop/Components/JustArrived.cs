using abvancedEshop.Data;
using Microsoft.AspNetCore.Mvc;

namespace abvancedEshop.Components
{
    public class JustArrved:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public JustArrved(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Products.Where(p=>p.IsArrived==true).ToList());
        }
    }
}
