using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hamoj_Web_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDropDownBindService _dropDownBindService;

        public OrderController(IOrderService orderService, ICurrentUserService currentUserService, IDropDownBindService dropDownBindService)
        {
            _orderService = orderService;
            _currentUserService = currentUserService;
            _dropDownBindService = dropDownBindService;
        }

        [HttpPost]
        public async Task<IActionResult> CustomerProductOrder(List<ProductDto> dto)
        {
            var order = await _orderService.AddOrder(dto.Where(d => d.Qty != 0).ToList(), _currentUserService.GetCurrentUserId());
            return Ok(new { data = order, status = true });
        }


        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var data = await _orderService.OrderList();
            var productList = await _orderService.GetProductData();
            var userList = await _dropDownBindService.BindVendorUserDropDown(_currentUserService.GetCurrentUserId());

            var result = new
            {
                Orders = data,
                ProductList = productList,
                UserList = userList.Select(user => new
                {
                    Id = user.Id,
                    Name = user.Name
                })
            };

            return Ok(new { data = result, status = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetOfficeNumber(string term)
        {
            var officeNoList = await _orderService.GetOfficeNumber(term);
            return Ok(new { data = officeNoList, status = true });
        }

        [HttpGet]
        public async Task<IActionResult> VendorAddOrder()
        {
            var CustomerList = await _dropDownBindService.BindCustomerDropDown();
            var CustomerLists = new SelectList(CustomerList, "Id", "Name");
            var productList = await _orderService.GetProductData();
            return Ok(new { data = productList, status = true });
        }

    }
}
