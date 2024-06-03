using Hamoj.DB.Migrations;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Hamoj.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Hamoj.web.Controllers;

[Authorize]

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly ICurrentUserService _currentUserService;

    public OrderController(IOrderService orderService, ICurrentUserService currentUserService)
    {
        _orderService = orderService;
        _currentUserService = currentUserService;
    }
    public async Task<IActionResult> Index()
    {
        var productList = await _orderService.GetProductData();
        return View(productList);
    }

    [HttpPost]
    public async Task<IActionResult> CustomerProductOrder([FromBody] List<CustomerProductOrder> dto)
    {

        var order = await _orderService.AddOrder(dto,_currentUserService.GetCurrentUserId());
        return Json(new { msg = "Success", status = true });
    }

    public async Task<IActionResult> OrderList()
    {
        return View();
    }
}


