﻿using Hamoj.DB.Enum;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
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
    private readonly IDropDownBindService _dropDownBindService;

    public OrderController(IOrderService orderService, ICurrentUserService currentUserService, IDropDownBindService dropDownBindService)
    {
        _orderService = orderService;
        _currentUserService = currentUserService;
        _dropDownBindService = dropDownBindService;
    }
    public async Task<IActionResult> Index()
    {
        var productList = await _orderService.GetProductData();
        return View(productList);
    }

    [HttpPost]
    public async Task<IActionResult> CustomerProductOrder(List<ProductDto> dto)
    {

        var order = await _orderService.AddOrder(dto.Where(dto => dto.Qty != 0).ToList(), _currentUserService.GetCurrentUserId());
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> OrderList()
    {
        var order = await _orderService.OrderList();
        ViewBag.ProductList = await _orderService.GetProductData();
        var UserList = await _dropDownBindService.BindVendorUserDropDown(_currentUserService.GetCurrentUserId());
        ViewBag.UserList = new SelectList(UserList, "Id", "Name");
        return View(order);
    }
            
    [HttpPost]
    public async Task<IActionResult> ConfirmOrder(int id, int status, List<OrderDataDto>qty)
    {
        var orderStatus = status == 1 ? OrderEnum.Deliver : OrderEnum.Cancel;
        var confirmorder = await _orderService.ConfirmOrder(id, orderStatus, qty);
        return Json(new { msg = "Success", status = true });
    }

    public async Task<IActionResult> AssignOrder(int VendorUserId, int OrderId)
    {
        var AssignOrder = await _orderService.AssignOrder(OrderId, VendorUserId);
        return Json(new { msg = "Success", status = true });
    }


    public async Task<IActionResult> VendorUserOrderList()
    {
        ViewBag.ProductList = await _orderService.GetProductData();
        var VendorUSer = await _orderService.VendorUSerOrderList(_currentUserService.GetCurrentUserId());
        return View(VendorUSer);
    }


    public async Task<IActionResult> VendorAddOrder()
    {
        var CustomerList = await _dropDownBindService.BindCustomerDropDown();
        ViewBag.CustomerList = new SelectList(CustomerList, "Id", "Name");
        var productList = await _orderService.GetProductData();
        return View(productList);
    }
}