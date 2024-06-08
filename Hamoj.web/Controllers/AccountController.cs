using Hamoj.DB.Migrations;
using Hamoj.Service.Dto;
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

    public AccountController(ILoginService loginService)
    {
        _loginService = loginService;
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
        if(dto.IsVendor ?? true)
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
            new Claim(ClaimTypes.Role, userRole),
        };

            var claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.Now.AddMinutes(100),
                        IsPersistent = false
                    })
                .ConfigureAwait(false);

            return RedirectToAction("Index", "Dashboard");
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
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, UserEnum.Customer.ToString()),
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.Now.AddMinutes(100),
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
            ViewBag.ErrorMessage = "Invalid username or password";
            return RedirectToAction("CustomerLogin", "Account");
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
                ExpiresUtc = DateTimeOffset.Now.AddMinutes(100),
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
            return RedirectToAction("SuperAdminLogin", "Account");
        }
    }

}
