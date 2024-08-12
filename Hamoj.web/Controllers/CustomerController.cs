using Hamoj.DB.Enum;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Hamoj.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Hamoj.web.Controllers;

[Authorize]

public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    public async Task<IActionResult> Index()
    {
        return View();

    }

    public async Task<IActionResult> BindData()
    {

        var Customerbind = await _customerService.GetAllAsync();
        return Json(new { data = Customerbind, status = true, });
    }

    public async Task<IActionResult> AddEdit(int id)
    {
        if (id > 0)
        {
            var Edit = await _customerService.GetDataById(id);
            return View(Edit);
        }
        return View(new CustomerDto());
    }

    [HttpPost]
    public async Task<IActionResult> AddEdit(CustomerDto dto)
    {
        var duplicate = await _customerService.FindDuplicate(dto.Office_No,dto.Mobile, dto.Id);
        if (duplicate != null)
        {
            ModelState.AddModelError("Office_No", "Office Number already exists.");
            ModelState.AddModelError("Mobile", "Mobile Number already exists.");
            return View(dto); // Return the view with errors if duplicate found
        }
        var AddEdit = _customerService.AddEditCustomer(dto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var delete = await _customerService.Delete(id);
        return Json(new { data = delete, status = true, });
    }

    public async Task<IActionResult> Dashboard()
    {
        return View();

    }
}
