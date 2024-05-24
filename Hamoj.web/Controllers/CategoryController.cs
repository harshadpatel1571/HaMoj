using Hamoj.Service.Interface;
using Microsoft.AspNetCore.Mvc;

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
            await _catagoryService.GetAllAsync();
            return View();
        }

        public async Task<IActionResult> BindData () 
        {

         var Categorybind =   await _catagoryService.GetAllAsync();


            return Json(new { data = Categorybind, status = true, });
        }
    }
}
