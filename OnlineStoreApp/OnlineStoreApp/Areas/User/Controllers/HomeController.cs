using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreApp.Models;

namespace OnlineStoreApp.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsAvailable)
                .ToListAsync();

            return View(products);
        }
    }
}