using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hamoj_Web_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VendorUserController : ControllerBase
    {
        private readonly IVendorUserService _VendorUserService;
        private readonly ICurrentUserService _currentUserService;

        public VendorUserController(IVendorUserService vendorUserService, ICurrentUserService currentUserService)
        {
            _VendorUserService = vendorUserService;
            _currentUserService = currentUserService;
        }


        //[HttpGet]
        //public async Task<IActionResult> BindData()
        //{
        //    var VendorUserbind = await _VendorUserService.GetAllAsync(_currentUserService.GetCurrentUserId());
        //    if (VendorUserbind == null)
        //    {

        //        return Ok(new { data = VendorUserbind, status = false, Message = "User Not Found" });
        //    }
        //    else
        //    {
        //        return Ok(new { data = VendorUserbind, status = true, });
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {

            if (id > 0)
            {
                var Edit = await _VendorUserService.GetDataById(id);
                return Ok(new { data = Edit, status = true, });
            }
            return Ok();
        }

        //[HttpPost]
        //public async Task<IActionResult> AddEdit(VendorUserDto dto)
        //{
        //    var duplicate = await _VendorUserService.FindDuplicate(dto.MobileNumber);
        //    if (duplicate != null && duplicate.id != dto.id)
        //    {
        //        ModelState.AddModelError("MobileNumber", "Mobile Number already exists.");
        //        return Ok(new { data = duplicate, status = true, });
        //    }

        //    var addEditResult = _VendorUserService.AddEdit(dto, _currentUserService.GetCurrentUserId());

        //    return Ok(new { data = addEditResult, status = true, });
        //}


    }
}
