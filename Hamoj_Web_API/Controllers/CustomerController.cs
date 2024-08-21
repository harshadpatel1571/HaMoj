using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hamoj_Web_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]

        public async Task<IActionResult> BindData()
        {

            var Customerbind = await _customerService.GetAllAsync();
            return Ok(new { data = Customerbind, status = true, });
        }


        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            if (id > 0)
            {
                var Edit = await _customerService.GetDataById(id);
                return Ok(new { data = Edit, status = true, });
            }
            return Ok(new CustomerDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(CustomerDto dto)
        {
            var duplicate = await _customerService.FindDuplicate(dto.Office_No, dto.Mobile, dto.Id);

            if (duplicate != null)
            {
                if (duplicate.Office_No == dto.Office_No)
                {
                    ModelState.AddModelError("Office_No", "Office Number already exists.");
                }

                if (duplicate.Mobile == dto.Mobile)
                {
                    ModelState.AddModelError("Mobile", "Mobile Number already exists.");
                }

                return Ok(new { data = duplicate, status = true, });
            }

            await _customerService.AddEditCustomer(dto);

            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _customerService.Delete(id);
            return Ok(new { data = delete, status = true, });
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            return Ok();

        }
    }
}
