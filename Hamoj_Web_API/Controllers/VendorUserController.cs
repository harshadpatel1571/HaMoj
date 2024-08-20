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

        public VendorUserController(ICurrentUserService currentUserService, IVendorUserService VendorUserService)
        {
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
            _VendorUserService = VendorUserService ?? throw new ArgumentNullException(nameof(VendorUserService));
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(VendorUserDto dto)
        {
            try
            {
                // Check if services are properly initialized
                if (_currentUserService == null || _VendorUserService == null)
                {
                    throw new InvalidOperationException("Services are not initialized.");
                }

                // Validate DTO
                if (dto == null)
                {
                    return BadRequest(new { status = false, message = "Invalid input data." });
                }

                if (string.IsNullOrEmpty(dto.MobileNumber))
                {
                    ModelState.AddModelError("MobileNumber", "Mobile Number is required.");
                    return BadRequest(new { status = false, message = "Mobile Number is required." });
                }

                // Check for duplicates
                var duplicate = await _VendorUserService.FindDuplicate(dto.MobileNumber);
                if (duplicate != null && duplicate.id != dto.id)
                {
                    ModelState.AddModelError("MobileNumber", "Mobile Number already exists.");
                    return Ok(new { data = duplicate, status = false, message = "Duplicate mobile number." });
                }

                // Add or Edit the vendor user
                var addEditResult = await _VendorUserService.AddEdit(dto, _currentUserService.GetCurrentUserId());

                return Ok(new { data = addEditResult, status = true, message = "Operation successful." });
            }
            catch (Exception ex)
            {
                // Log exception for debugging
                // e.g., _logger.LogError(ex, "Error in AddEdit method");
                return StatusCode(500, new { status = false, message = ex.Message });
            }
        }


        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            try
            {
                if (id > 0)
                {
                    var Edit = await _VendorUserService.GetDataById(id);
                    if (Edit != null)
                    {
                        return Ok(new { data = Edit, status = true });
                    }
                    else
                    {
                        return NotFound(new { status = false, message = "Data not found." });
                    }
                }
                return BadRequest(new { status = false, message = "Invalid ID." });
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return StatusCode(500, new { status = false, message = ex.Message });
            }
        }
    }
}
