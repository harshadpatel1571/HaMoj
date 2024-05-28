using Hamoj.Service.Interface;
using Hamoj.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hamoj.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> BindData()
        {

            var Customerbind = await _productService.GetAllAsync();
            return Json(new { data = Customerbind, status = true, });
        }

        public async Task<IActionResult> AddEdit(int id)
        {
            //if (id > 0)
            //{
            //    var Edit = await _productService.GetDataById(id);
            //    return View(Edit);
            //}
            return View();
        }
    }
}
