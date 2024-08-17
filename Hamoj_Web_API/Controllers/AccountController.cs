using Hamoj.DB.Enum;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hamoj_Web_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ICustomerService _customerService;

        public AccountController(ILoginService loginService, ICustomerService customerService)
        {
            _loginService = loginService;
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _loginService.CheakVendorLogin(dto);

            if (user == null)
            {
                return Ok(new { data = user, status = false, Message = "User Not Found" });
            }
            else
            {
                var userRole = "";
                if (dto.IsVendor ?? true)
                {
                    userRole = UserEnum.Vendor.ToString();
                }
                else
                {
                    userRole = UserEnum.vendorUser.ToString();
                }

                return Ok(new { data = user, status = true, });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CustomerLogin(LoginDto dto)
        {
            var customer = await _loginService.CheakCustomerLogin(dto);
            if (customer == null)
            {
                return Ok(new { data = customer, status = false, Message = "User Not Found" });
            }
            else
            {
                return Ok(new { data = customer, status = true, });
            }
        }
    }
}
