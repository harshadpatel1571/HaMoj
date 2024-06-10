using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Hamoj.web.Controllers;

[Authorize]
public class CategoryController : Controller
{
    
    private readonly ICatagoryService _catagoryService;

    //find to base path 
    private readonly IWebHostEnvironment _webHostEnvironment;
    public CategoryController(ICatagoryService catagoryService, IWebHostEnvironment webHostEnvironment)
    {
        _catagoryService = catagoryService;
        _webHostEnvironment = webHostEnvironment;
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

    public async Task<IActionResult> AddEdit(CategoryDto dto)
    {
        // Check if a file exists and set the image name in the DTO
        if (dto.Imagefile != null)
        {
            dto.Image = dto.Imagefile.FileName;
        }

        var duplicate = await _catagoryService.FindDuplicate(dto.Name, dto.Id);
        if (duplicate != null)
        {
            ModelState.AddModelError("Name", "Category name already exists.");
            return View(dto); 
        }

        // Add or edit the category
        var addEditResult = await _catagoryService.AddEdit(dto); 

        // Save the image to the folder if the add/edit was successful
        if (addEditResult != null)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "CategoryImage");
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
        var delete = await _catagoryService.Delete(id);
        return Json(new {data = delete,status=true,});
    }
}
