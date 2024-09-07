using Hamoj.DB.Datamodel;
using Hamoj.DB.Enum;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<IActionResult> CustomerProductOrder(List<ProductOrderDto> dto, int customerId, int vendorId)
        {

            var productOrderDtos = new List<ProductDto>();

            foreach (var product in dto)
            {
                var productOrderDto = new ProductDto
                {
                    Office_no = customerId,
                    Id = product.ProductId,
                    Qty = product.Quantity,
                    Price = product.Price
                };
                productOrderDtos.Add(productOrderDto);
            }

            var order = await _orderService.AddOrder(productOrderDtos.Where(d => d.Qty != 0).ToList(), customerId);
            var orderData = await _orderService.GetProductData();

            //for (int i = 0; i < 3; i++)
            //{
            //    var order = await _orderService.AddOrder(productOrderDtos.Where(d => d.Qty != 0).ToList(), customerId);
            //    _ = await _orderService.GetProductData();
            //}

            return Ok(new { data = orderData, status = true });
        }


        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var data = await _orderService.OrderList();
            var productList = await _orderService.GetProductData();
            var userList = await _dropDownBindService.BindVendorUserDropDown((int)UserEnum.Customer);

            var response = new
            {
                Orders = data,
                Products = productList,
                Users = userList.Select(user => new { user.Id, user.Name })
            };

            return Ok(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetOfficeNumber(string OfficeNumber)
        {
            var officeNoList = await _orderService.GetOfficeNumber(OfficeNumber);
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


        [HttpPost]
        public async Task<IActionResult> ConfirmOrder(int OrderId, int status, List<OrderDataDto> Qty)
        {
            var orderStatus = status == 1 ? OrderEnum.Deliver : OrderEnum.Cancel;
            var confirmorder = await _orderService.ConfirmOrder(OrderId, orderStatus, Qty);
            return Ok(new { msg = "Success", status = true });
        }

        [HttpPost]

        public async Task<IActionResult> AssignOrder(int VendorUserId, int OrderId, List<OrderDataDto> Qty)
        {
            var AssignOrder = await _orderService.AssignOrder(OrderId, VendorUserId, Qty);
            return Ok(new { msg = "Success", status = true });
        }

        [HttpGet]
        public async Task<IActionResult> VendorUserOrderList(int ID)
        {
            var data = await _orderService.VendorUSerOrderList(ID);
            var productList = await _orderService.GetProductData();
            var userList = await _dropDownBindService.BindVendorUserDropDown((int)UserEnum.vendorUser);

            var response = new
            {
                Orders = data,
                //Products = productList,
                //Users = userList.Select(user => new { user.Id, user.Name })
            };

            return Ok(new { data = response, status = true });
        }





    }
}
