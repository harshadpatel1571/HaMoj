using Microsoft.AspNetCore.Mvc;

namespace Hamoj.web.Controllers;
public class VendorReportController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
