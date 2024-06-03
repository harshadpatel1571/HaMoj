using Microsoft.AspNetCore.Mvc;

namespace Hamoj.web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerDashboard()
        {
            return View();
        }
    }
}
