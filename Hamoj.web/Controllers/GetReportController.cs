using Azure.Core;
using Hamoj.DB.Datamodel;
using Hamoj.Service.Interface;
using Hamoj.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hamoj.web.Controllers
{
    public class GetReportController : Controller
    {
        private readonly IGetReportService _getReportService;
        private readonly ICurrentUserService _currentUserService;


        public GetReportController(IGetReportService getReportService, ICurrentUserService getCurrentUserId)
        {
            _getReportService = getReportService;
            _currentUserService = getCurrentUserId;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetReport()
        {
            var getReport = await _getReportService.GetReportAsync(_currentUserService.GetCurrentUserId());
            return Json(new { data = getReport, status = true });
        }

        [HttpPost]
        public async Task<IActionResult> GetOrderDetails(int id)
        {
            var orderDetails = await _getReportService.GetOrderDetails(id);
            return Json(new { data = orderDetails, status = true });

        }
    }
}