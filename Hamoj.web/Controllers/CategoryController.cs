using Hamoj.DB.Migrations;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Hamoj.web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICatagoryService _catagoryService;
        public CategoryController(ICatagoryService catagoryService)
        {
            _catagoryService = catagoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> BindData () 
        {

         var Categorybind =   await _catagoryService.GetAllAsync();


            return Json(new { data = Categorybind, status = true, });
        }

        public async Task<IActionResult> AddEdit(int id)
        {
            if (id > 0)
            {
                var Edit = await _catagoryService.GetDataById(id);
                return View(Edit);
            }
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> AddEdit(CatrgoryDto dto)
        {
            var AddEdit = _catagoryService.AddEditCategory(dto);
            return RedirectToAction("Index");
        }
    }

}
