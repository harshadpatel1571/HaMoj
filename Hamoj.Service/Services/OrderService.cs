using Hamoj.DB.Context;
using Hamoj.DB.Datamodel;
using Hamoj.DB.Enum;
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
                VendorID = 1,
                Gst = 0,
                GrandTotal = 0, 
                OrderStatus = (int)OrderEnum.Pending,
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
                    OrderStatus = (int)OrderEnum.Pending,
                    is_Active = true,
                    is_Delete = false,
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

        public async Task<bool> ConfirmOrder(int OrdersID, OrderEnum status)
        {
            try
            {
                // this code for update order details :
                var orderDetails = await _context.OrderDetails.Where(x => x.Id == OrdersID).FirstOrDefaultAsync();
                orderDetails.OrderStatus = (int)status;

                _context.OrderDetails.Update(orderDetails);
                _context.SaveChanges();


                // this code for find morethen one order details if not then update order.
                var order = await _context.Order.Where(x => x.ID == orderDetails.OrderId).FirstOrDefaultAsync();
                var checkExtra = await _context.OrderDetails.Where(x => x.OrderId == order.ID && x.OrderStatus == (int)OrderEnum.Pending).ToListAsync();
                if (checkExtra.Count == 0)
                {
                    // no order details found.
                    order.OrderStatus = (int)status;
                    _context.Order.Update(order);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
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

        public async Task<List<OrderDetailsDto>> OrderList()
        {
            return await _context.OrderDetails.Where(x=>x.OrderStatus == (int)OrderEnum.Pending).Select(x => new OrderDetailsDto
            {
                Id = x.Id,
                Qty = x.Qty,
                productDto = new ProductDto
                {
                    Name = x.product.Name,
                    Image = x.product.Image,
                },
                orderDto = new OrderDto
                {
                    customerDto = new CustomerDto
                    {
                        Office_No = x.order.Customer.Office_No
                    },
                },
               
            }).ToListAsync();
        }

    }
}