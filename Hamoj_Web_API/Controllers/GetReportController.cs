using Hamoj.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hamoj_Web_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GetReportController : ControllerBase
    {
        private readonly IGetReportService _getReportService;
        private readonly ICurrentUserService _currentUserService;


        public GetReportController(IGetReportService getReportService, ICurrentUserService getCurrentUserId)
        {
            _getReportService = getReportService;
            _currentUserService = getCurrentUserId;
        }

        [HttpPost]
        public async Task<IActionResult> GetReport(DateTime fromDate, DateTime toDate)
        {
            var getReport = await _getReportService.GetReportAsync(_currentUserService.GetCurrentUserId(), fromDate, toDate);
            return Ok(new { data = getReport, status = true });
        }
    }
}
