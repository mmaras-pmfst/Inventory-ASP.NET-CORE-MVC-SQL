using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Items()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return View();
        }
        public IActionResult Stocks()
        {
            return View();
        }
        public IActionResult Transactions()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Purchases()
        {
            return View();
        }
        
    }
}
