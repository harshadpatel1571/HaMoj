using Microsoft.AspNetCore.Mvc;

namespace Hamoj.web.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
