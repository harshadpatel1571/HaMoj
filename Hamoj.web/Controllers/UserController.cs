using Hamoj.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hamoj.web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
