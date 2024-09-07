using Hamoj.DB.Datamodel;
using Hamoj.DB.Enum;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        [HttpGet]

        public async Task<IActionResult> BindData(int Id)
        {

            var VendorUserbind = await _VendorUserService.GetAllAsync(Id);
            return Ok(new { data = VendorUserbind, status = true, });
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {

            if (id > 0)
            {
                var Edit = await _VendorUserService.GetDataById(id);
                return Ok(new { data = Edit, status = true, });
            }
            return Ok(new VendorUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(VendorUserDto dto)
        {
            // Check for duplicate mobile number
            var duplicate = await _VendorUserService.FindDuplicate(dto.MobileNumber);
            if (duplicate != null && duplicate.id != dto.id)
            {
                ModelState.AddModelError("MobileNumber", "Mobile Number already exists.");
                return Ok(new { data = duplicate, status = true, });
            }

            // If no duplicate, proceed with add/edit
            var addEditResult = _VendorUserService.AddEdit(dto,1);

            return Ok(new { data = addEditResult, status = true, });
        }
    }
}
