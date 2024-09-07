using Hamoj.Service.Interface;
using Hamoj.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hamoj_Web_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VendorReportController : ControllerBase
    {
        private readonly IDropDownBindService _dropDownBindService;
        private readonly IGetReportService _getReportService;

        public VendorReportController(IDropDownBindService dropDownBindService, IGetReportService getReportService)
        {
            _dropDownBindService = dropDownBindService;
            _getReportService = getReportService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customerList = await _dropDownBindService.BindCustomerDropDown();
            var customerLists = customerList.Select(c => new { Id = c.Id, Name = c.Name }).ToList();

            return Ok(new { data = customerLists, status = true });
        }

        [HttpGet]

        public async Task<IActionResult> BindData(int customer, DateTime fromDate, DateTime toDate)
        {
            var data = await _getReportService.GetCustomerReport(customer, fromDate, toDate);
            return Ok(new { data = data, status = true, });
        }

        [HttpGet]

        public async Task<IActionResult> UpdateStatus(int customerId, DateTime fromDate, DateTime toDate)
        {
            var data = await _getReportService.GetOrder(customerId, fromDate, toDate);
            return Ok(new { data = data, status = true, });
        }
    }



}
