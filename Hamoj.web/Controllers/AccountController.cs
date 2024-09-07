﻿using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using Hamoj.DB.Enum;
using Microsoft.AspNetCore.Authorization;
using Hamoj.DB.Datamodel;
using Hamoj.Service.Services;

namespace Hamoj.web.Controllers;


public class AccountController : Controller
{
    private readonly ILoginService _loginService;
    private readonly ICustomerService _customerService;

    public AccountController(ILoginService loginService, ICustomerService customerService)
    {
        _loginService = loginService;
        _customerService = customerService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _loginService.CheakVendorLogin(dto);
        var userRole = "";

        if (dto.IsVendor ?? true)
        {
            userRole = UserEnum.Vendor.ToString();
        }
        else
        {
            userRole = UserEnum.vendorUser.ToString();
        }

        if (user != null)
        {
            var claims = new[]
            {
            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.MobilePhone, user.MobileNumber),
            new Claim(ClaimTypes.Role, userRole),
        };

            var claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.Now.AddMinutes(500),
                    IsPersistent = false
                })
            .ConfigureAwait(false);

            if (userRole == UserEnum.Vendor.ToString())
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("VendorUserOrderList", "Order");
            }
        }
        else
        {
            ViewBag.ErrorMessage = "Invalid mobilenumber or password";
            return View("Index");
        }
    }


    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme)
            .ConfigureAwait(false);

        return RedirectToAction("Index", "Account");
    }

    public async Task<IActionResult> CustomerLogout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme)
            .ConfigureAwait(false);

        return RedirectToAction("CustomerLogin", "Account");
    }


    public async Task<IActionResult> CustomerLogin()
    {
        return View();

    }

    [HttpPost]
    public async Task<IActionResult> CustomerLogin(LoginDto dto)
    {
        var user = await _loginService.CheakCustomerLogin(dto);

        if (user != null)
        {
            var claims = new[]
            {
            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.MobilePhone, user.MobileNumber),
            new Claim("UserName", user.Name),
            new Claim(ClaimTypes.Role, UserEnum.Customer.ToString()),
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.Now.AddMinutes(500),
                IsPersistent = false
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            ).ConfigureAwait(false);

            return RedirectToAction("CustomerDashboard", "Dashboard");
        }
        else
        {
            // Add a model error for invalid credentials
            ViewBag.ErrorMessage = "Invalid username or password";

            // Return the view with errors
            return View("CustomerLogin");
        }
    }



    public async Task<IActionResult> SuperAdminLogin()
    {
        return View();

    }

    [HttpPost]
    public async Task<IActionResult> SuperAdminLogin(UserLoginDto dto)
    {
        var admin = await _loginService.CheakSuperAdminLogin(dto);

        if (admin != null)
        {
            var claims = new[]
            {
            new Claim("Id", admin.Id.ToString()),
            new Claim(ClaimTypes.Email, admin.Email),
            new Claim(ClaimTypes.Name, admin.Name),
            new Claim(ClaimTypes.Role, UserEnum.Admin.ToString()),
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.Now.AddMinutes(500),
                IsPersistent = false
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            ).ConfigureAwait(false);

            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.ErrorMessage = "Invalid username or password";
            return View();
        }
    }

    public async Task<IActionResult> CustomerRegister()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CustomerRegister(CustomerDto dto)
    {
        var duplicate = await _customerService.FindDuplicate(dto.Office_No, dto.Mobile, dto.Id);
        if (duplicate != null)
        {
            ModelState.AddModelError("Office_No", "Office Number already exists.");
            ModelState.AddModelError("Mobile", "Mobile Number already exists.");
            return View();
        }
        var CustomerRegister = _customerService.CustomerRegister(dto);
        return RedirectToAction("CustomerLogin");
    }

}
