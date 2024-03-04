// Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;

namespace Laba5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}