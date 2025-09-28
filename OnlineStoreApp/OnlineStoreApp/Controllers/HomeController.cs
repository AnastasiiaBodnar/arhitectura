using Microsoft.AspNetCore.Mvc;

namespace OnlineStoreApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}