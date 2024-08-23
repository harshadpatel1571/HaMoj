using Hamoj.Service.Interface;
using Hamoj.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hamoj.web.Controllers;
public class VendorReportController : Controller
{
    private readonly IDropDownBindService _dropDownBindService;
    private readonly IGetReportService _getReportService;

    public VendorReportController(IDropDownBindService dropDownBindService,IGetReportService getReportService)
    {
        _dropDownBindService = dropDownBindService;
        _getReportService = getReportService;
    }
    public async Task<IActionResult> Index()
    {
        var CustomerList = await _dropDownBindService.BindCustomerDropDown();
        ViewBag.CustomerList = new SelectList(CustomerList, "Id", "Name");
        return View();
    }

    public async Task<IActionResult> BindData(int customer, DateTime fromDate , DateTime toDate)
    {
        var data = await _getReportService.GetCustomerReport(customer , fromDate , toDate);
        return Json(new { data = data, status = true, });
    }

    public async Task<IActionResult>UpdateStatus(int customerId, DateTime fromDate, DateTime toDate)
    {
        var data = await _getReportService.GetOrder(customerId, fromDate, toDate);
        return Json(new { data = data, status = true, });
    }
}
