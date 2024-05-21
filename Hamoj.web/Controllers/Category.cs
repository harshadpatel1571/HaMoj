using Hamoj.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hamoj.web.Controllers
{
    public class Category : Controller
    {
        private readonly ICatagoryService _catagoryService;
        public Category(ICatagoryService catagoryService)
        {
            _catagoryService = catagoryService;
        }

        public async Task<IActionResult> Index()
        {
            await _catagoryService.GetAllAsync();
            return View();
        }
    }
}
