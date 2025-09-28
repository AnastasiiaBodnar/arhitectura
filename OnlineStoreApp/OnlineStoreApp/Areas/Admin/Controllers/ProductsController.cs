using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreApp.Models;

namespace OnlineStoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            try
            {
                var products = await _context.Products.Include(p => p.Category).ToListAsync();
                return View(products);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Помилка при завантаженні товарів: " + ex.Message;
                return View(new List<Product>());
            }
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var product = await _context.Products
                    .Include(p => p.Category)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Помилка при завантаженні деталей товару: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Admin/Products/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                var categories = await _context.Categories.ToListAsync();
                ViewBag.Categories = categories;

                // Створюємо новий продукт з базовими значеннями
                var product = new Product
                {
                    IsAvailable = true,
                    Price = 0
                };

                return View(product);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Помилка при підготовці форми: " + ex.Message;
                ViewBag.Categories = new List<Category>();
                return View(new Product { IsAvailable = true });
            }
        }

        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                // Перевіряємо, чи модель валідна
                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Товар успішно створено!";
                    return RedirectToAction(nameof(Index));
                }

                // Якщо модель не валідна, повертаємо форму з помилками
                var categories = await _context.Categories.ToListAsync();
                ViewBag.Categories = categories;
                return View(product);
            }
            catch (Exception ex)
            {
                var categories = await _context.Categories.ToListAsync();
                ViewBag.Categories = categories;
                ViewBag.ErrorMessage = "Помилка при створенні товару: " + ex.Message;
                return View(product);
            }
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                var categories = await _context.Categories.ToListAsync();
                ViewBag.Categories = categories;
                return View(product);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Помилка при завантаженні товару для редагування: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Товар успішно оновлено!";
                    return RedirectToAction(nameof(Index));
                }

                var categories = await _context.Categories.ToListAsync();
                ViewBag.Categories = categories;
                return View(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                var categories = await _context.Categories.ToListAsync();
                ViewBag.Categories = categories;
                ViewBag.ErrorMessage = "Помилка при оновленні товару: " + ex.Message;
                return View(product);
            }
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var product = await _context.Products
                    .Include(p => p.Category)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Помилка при завантаженні товару для видалення: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Товар успішно видалено!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Товар не знайдено!";
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Помилка при видаленні товару: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}