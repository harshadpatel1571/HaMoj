using Hamoj.Service.Interface;
using Hamoj.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hamoj.web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        private readonly ICurrentUserService _currentUserService;


        public DashboardController(IDashboardService dashboardService , ICurrentUserService currentUserService)
        {
            _dashboardService = dashboardService;
            _currentUserService = currentUserService;
        }

        public async Task<IActionResult> Index()
        {
			var totalPaidAmount = await _dashboardService.TotalPaidAmount();
			ViewBag.paidtotal = totalPaidAmount;
            var totalPendingAmount = await _dashboardService.TotalPendingAmount();
            ViewBag.pendingtotal = totalPendingAmount;
            return View();
		}

        public  async Task<IActionResult> CustomerDashboard()
        {
            var totalAmount = await _dashboardService.UserTotalAmount(_currentUserService.GetCurrentUserId());
            ViewBag.total = totalAmount;
            return View();
        }
    }
}
