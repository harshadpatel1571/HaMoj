using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Hamoj.Service.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading;

namespace Hamoj.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IDropDownBindService _dropDownBrindService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductService productService , IDropDownBindService dropDownBrindService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _dropDownBrindService = dropDownBrindService;
            _webHostEnvironment = webHostEnvironment;
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
            var CategoryList = await _dropDownBrindService.BindCategoryDropDown();
            ViewBag.CategoryList = new SelectList(CategoryList, "Id", "Name");

            if (id > 0)
            {
                var Edit = await _productService.GetDataById(id);
                return View(Edit);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(ProductDto dto)
        {
            // Check if a file exists and set the image name in the DTO
            if (dto.Imagefile != null)
            {
                dto.Image = dto.Imagefile.FileName;
            }

            // Add or edit the category
            var addEditResult = await _productService.AddEditProduct(dto);

            // Save the image to the folder if the add/edit was successful
            if (addEditResult != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImage");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                if (dto.Imagefile != null)
                {
                    string filePath = Path.Combine(uploadsFolder, dto.Imagefile.FileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await dto.Imagefile.CopyToAsync(fileStream);
                    }
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _productService.DeleteProduct(id);
            return Json(new { data = delete, status = true, });
        }
    }

}
