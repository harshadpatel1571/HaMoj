using Hamoj.DB.Context;
using Hamoj.DB.Datamodel;
using Hamoj.DB.Enum;
using Hamoj.DB.Migrations;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hamoj.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly HamojDBContext _context;
      

        public OrderService(HamojDBContext context)
        {
            _context = context;
        } 

        public async Task<bool> AddOrder(List<CustomerProductOrder> dto, int CustomerID)
        {
            var order = new Order
            {
                CustomerId = CustomerID,  
                VendorID = 5003,   
                Gst = 0,
                GrandTotal = 0,  
                OrderStatus = (int)OrderEnum.Padding,
                is_Active = true,
                is_Delete = false,
                Create_Date = DateTime.Now,
                Create_by = 1,   
                orderDetailsList = new List<OrderDetails>()
            };

            foreach (var item in dto)
            {
                var product = await _context.Product
                    .Where(x => x.Id == item.Id)
                    .FirstOrDefaultAsync();

                var orderDetails = new OrderDetails
                {
                    ProductId = item.Id,
                    Amount = product.Price,
                    Qty = item.Qtty,
                    TotalAmounnt = product.Price * item.Qtty,
                    OrderStatus = (int)OrderEnum.Padding,
                    is_Active = product.is_Active,
                    is_Delete = product.is_Delete,
                    Create_Date = DateTime.Now,
                    Create_by = 1
                };

                order.orderDetailsList.Add(orderDetails);
                order.GrandTotal += orderDetails.TotalAmounnt; 
            }

            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductDto>> GetProductData()
        {
            return await _context.Product.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Price = x.Price
            }).ToListAsync();
        }
    }
}
