﻿using Hamoj.DB.Context;
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

        public async Task<bool> AddOrder(List<ProductDto> dto, int CustomerID)
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
                    Qty = item.Qty,
                    TotalAmounnt = product.Price * item.Qty,
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

        public async Task<bool> AssignOrder(int OrderId, int VendorUserId)
        {
            try
            {
                var data = await _context.OrderDetails.Where(x => x.OrderId == OrderId).FirstOrDefaultAsync();
                data.VendorUserId = VendorUserId;
                _context.OrderDetails.Update(data);
                _context.SaveChanges();

                return true;
            }

            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> ConfirmOrder(int OrdersID, OrderEnum status, int qtty)
        {
            try
            {
                // this code for update order details :
                var orderDetails = await _context.OrderDetails.Where(x => x.OrderId == OrdersID).ToListAsync();
                foreach (var detail in orderDetails)
                {
                    detail.OrderStatus = (int)status;
                }

                _context.OrderDetails.UpdateRange(orderDetails);
                await _context.SaveChangesAsync();



                // this code for find morethen one order details if not then update order.
                var order = await _context.Order.Where(x => x.ID == OrdersID).FirstOrDefaultAsync();
                    order.OrderStatus = (int)status;
                    _context.Order.Update(order);
                    _context.SaveChanges();


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

        public async Task<List<OrderDto>> OrderList()
        {
            var orders = await _context.Order.Where(x=>x.OrderStatus == (int)OrderEnum.Pending).Select(x => new OrderDto
            {
                ID = x.ID,
                orderDetailsListDto = x.orderDetailsList.Select(o => new OrderDetailsDto
                {
                    Id = o.Id,
                    Qty = o.Qty,
                    ProductId = o.ProductId,
                }).ToList(),
                customerDto = new CustomerDto
                {
                    Id = x.Customer.Id,
                    Name = x.Customer.Name,
                    Office_No = x.Customer.Office_No
                },
                GrandTotal = x.GrandTotal,
                Gst = x.Gst
            }).ToListAsync();

            return orders;
        }

        public async Task<List<OrderDetailsDto>> VendorUSerOrderList(int Id)
        {
            return await _context.OrderDetails.Where(x => x.VendorUserId == Id & x.OrderStatus == (int)OrderEnum.Pending).Select(x => new OrderDetailsDto
            {
                Id = x.Id,
                Qty = x.Qty,
                VendorUserId = x.VendorUserId,
                productDto = new ProductDto
                {
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