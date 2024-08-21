using Hamoj.DB.Datamodel;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hamoj_Web_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet]
        public async Task<IActionResult> BindData()
        {
            var vendorbind = await _vendorService.GetAllAsync();
            return Ok(new { data = vendorbind, status = true, });
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            if (id > 0)
            {
                var Edit = await _vendorService.GetDataById(id);
                return Ok(new { data = Edit, status = true, });

            }
            return Ok();

        }

        [HttpPost]
        public async Task<IActionResult> AddEdit([FromBody] VendorDto dto)
        {
            var duplicate = await _vendorService.FindDuplicate(dto.MobileNumber, dto.Id);
            if (duplicate != null)
            {
                ModelState.AddModelError("mobileNumber", "Contact Phone already exists.");
                return Ok(new { data = duplicate, status = true });
            }

            var addEdit = await _vendorService.AddEditVendor(dto);
            return Ok(new { data = addEdit, status = true });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var Delete = await _vendorService.Delete(id);
            return Ok(new { data = Delete, status = true, });
        }

        [HttpGet]
        public IActionResult Payment()
        {
            return Ok();
        }
    }
}
