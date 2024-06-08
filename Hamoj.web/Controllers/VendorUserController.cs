using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Hamoj.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hamoj.web.Controllers
{
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
        public async Task< IActionResult> AddEdit(VendorUserDto dto)
        {


            var AddEdit = _VendorUserService.AddEdit(dto, _currentUserService.GetCurrentUserId());

            var Duplicate = await _VendorUserService.FindDuplicate(dto.MobileNumber);
            if (Duplicate != null)
            {

                ModelState.AddModelError("mobileNumber", "Mobile Number is already exists.");

                return View(dto);
            }

            return RedirectToAction("Index");
        }
    }
}
