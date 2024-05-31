using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Hamoj.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Hamoj.web.Controllers
{
    [Authorize]
    public class VendorController : Controller
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> BindData()
        {
            var vendorbind = await _vendorService.GetAllAsync();

            return Json(new { data = vendorbind, status = true, });
        }

        public async Task<IActionResult> AddEdit(int id)
        {
            if(id>0)
            {
                var Edit = await _vendorService.GetDataById(id);
                return View(Edit);

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(VendorDto dto)
        {
            var Duplicate = await _vendorService.FindDuplicate(dto.Email,dto.Contact_Phone,dto.Id);
            if(Duplicate != null)
            {
            
                ModelState.AddModelError("Email", "Email already exists.");
                ModelState.AddModelError("Contact_Phone", "Contact Phone already exists.");
                
                return View(dto);
            }
            var AddEdit = await _vendorService.AddEditVendor(dto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) 
        {
            var Delete = await _vendorService.Delete(id);
            return Json(new {data= Delete,status = true,});
        }      
    }
}
