using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Hamoj.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hamoj.web.Controllers;
[Authorize]


public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> BindData()
    {

        var userbind = await _userService.GetAllAsync();


        return Json(new { data = userbind, status = true, });
    }

    public async Task<IActionResult> AddEdit(int id)
    {
        if (id > 0)
        {
            var Edit = await _userService.GetDataById(id);
            return View(Edit);

        }
        return View(new UserDto());
    }

    [HttpPost]
    public async Task<IActionResult> AddEdit(UserDto dto)
    {
        var Duplicate = await _userService.FindDuplicate(dto.Email,dto.Id);
        if(Duplicate != null)
        {
            ModelState.AddModelError("Email", "Email already exists."); 
            return View(dto);
        }
        var AddEdit = await _userService.AddEdit(dto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var Delete = await _userService.Delete(id);
        return Json(new { data = Delete, status = true, });
    }
}
