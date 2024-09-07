using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Hamoj.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hamoj.web.Controllers
{
    [Authorize]
    public class VendorUserController : Controller
    {
        private readonly IVendorUserService _VendorUserService;
        private readonly ICurrentUserService _currentUserService;

        public VendorUserController(IVendorUserService vendorUserService, ICurrentUserService currentUserService)
        {
         _VendorUserService = vendorUserService;
            _currentUserService = currentUserService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BindData()
        {

            var VendorUserbind = await _VendorUserService.GetAllAsync(_currentUserService.GetCurrentUserId());
            return Json(new { data = VendorUserbind, status = true, });
        }

        public async Task<IActionResult> AddEdit(int id)
        {

            if (id > 0)
            {
                var Edit = await _VendorUserService.GetDataById(id);
                return View(Edit);
            }
            return View(new VendorUserDto());
        }


        [HttpPost]
        public async Task<IActionResult> AddEdit(VendorUserDto dto)
        {
            // Check for duplicate mobile number
            var duplicate = await _VendorUserService.FindDuplicate(dto.MobileNumber);
            if (duplicate != null && duplicate.id != dto.id)
            {
                ModelState.AddModelError("MobileNumber", "Mobile Number already exists.");
                return View(dto);
            }

            // If no duplicate, proceed with add/edit
            var addEditResult = _VendorUserService.AddEdit(dto, _currentUserService.GetCurrentUserId());

            return RedirectToAction("Index");
        }



    }
}
