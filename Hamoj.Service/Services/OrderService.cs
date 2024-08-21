﻿using Hamoj.DB.Context;
using Hamoj.DB.Datamodel;
using Hamoj.DB.Enum;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

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
            // Check if there is at least one product with Qty > 0
            if (!dto.Any(item => item.Qty > 0))
            {
                return false; // Return false or handle the error as needed
            }

            var order = new Order
            {
                CustomerId = CustomerID,
                VendorID = 4,
                Gst = 0,
                GrandTotal = 0,
                OrderStatus = (int)OrderEnum.Pending,
                is_Active = true,
                is_Delete = false,
                Create_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30),
                Create_by = 1,
                orderDetailsList = new List<OrderDetails>()
            };

            foreach (var item in dto)
            {
                if (item.Qty <= 0) continue; 

                var product = await _context.Product
                    .Where(x => x.Id == item.Id)
                    .FirstOrDefaultAsync();

                if (product == null) continue; 

                var orderDetails = new OrderDetails
                {
                    ProductId = item.Id,
                    Amount = product.Price,
                    Qty = item.Qty,
                    TotalAmounnt = product.Price * item.Qty,
                    OrderStatus = (int)OrderEnum.Pending,
                    is_Active = true,
                    is_Delete = false,
                    Create_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30),
                    Create_by = 1
                };

                order.orderDetailsList.Add(orderDetails);
                order.GrandTotal += orderDetails.TotalAmounnt;
            }

            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> AssignOrder(int OrderId, int VendorUserId, List<OrderDataDto> qty)
        {
            try
            {
                var data = await _context.Order.Where(x => x.ID == OrderId).FirstOrDefaultAsync();
                data.VendorUserId = VendorUserId;
                _context.Order.Update(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public async Task<bool> ConfirmOrder(int OrdersID, OrderEnum status, List<OrderDataDto> qty)
        {
            try
            {

                // this code for find morethen one order details if not then update order.
                var orderDetailsToDelete = await _context.OrderDetails.Where(x => x.OrderId == OrdersID).ToListAsync();
                _context.OrderDetails.RemoveRange(orderDetailsToDelete);
                await _context.SaveChangesAsync();

                var OrderDetailsList = new List<OrderDetails>();

                foreach (var item in qty)
                {
                    var product = await _context.Product
                        .Where(x => x.Id == item.Id)
                        .FirstOrDefaultAsync();

                    var orderDetails = new OrderDetails
                    {
                        OrderId = OrdersID,
                        ProductId = item.Id,
                        Amount = product.Price,
                        Qty = item.Qty,
                        TotalAmounnt = product.Price * item.Qty,
                        OrderStatus = (int)status,
                        is_Active = true,
                        is_Delete = false,
                        Create_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30),
                        Create_by = 1
                    };
                    OrderDetailsList.Add(orderDetails);

                }

                _context.OrderDetails.AddRange(OrderDetailsList);
                _context.SaveChanges();
                // this code for find more then one order details if not then update order.
                var order = await _context.Order.Where(x => x.ID == OrdersID).FirstOrDefaultAsync();
                order.OrderStatus = (int)status;
                order.GrandTotal = OrderDetailsList.Select(x => x.TotalAmounnt).Sum();
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
            var orders = await _context.Order.Where(x => x.VendorUserId == null & x.OrderStatus == (int)OrderEnum.Pending).Select(x => new OrderDto
            {
                ID = x.ID,
                //orderDetailsListDto = x.orderDetailsList.Select(o => new OrderDetailsDto
                //{
                //    Id = o.Id,
                //    Qty = o.Qty,
                //    ProductId = o.ProductId,
                //}).ToList(),
                //customerDto = new CustomerDto
                //{
                //    Id = x.Customer.Id,
                //    Name = x.Customer.Name,
                //    Office_No = x.Customer.Office_No
                //},
                GrandTotal = x.GrandTotal,
                Gst = x.Gst
            }).ToListAsync();

            return orders;
        }

        public async Task<bool> VendorAddOrder(List<ProductDto> dto, int? VendorUSerId)
        {
            var customerid = await _context.Customer.Where(x => x.Office_No == dto.Select(x => x.Office_no).FirstOrDefault()).Select(x => x.Id).FirstOrDefaultAsync();

            var order = new Order
            {
                CustomerId = customerid,
                VendorID = 4,
                VendorUserId = VendorUSerId,
                Gst = 0,
                GrandTotal = 0,
                OrderStatus = (int)OrderEnum.Deliver,
                is_Active = true,
                is_Delete = false,
                Create_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30),
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
                    OrderStatus = (int)OrderEnum.Deliver,
                    is_Active = true,
                    is_Delete = false,
                    Create_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30),
                    Create_by = 1
                };

                order.orderDetailsList.Add(orderDetails);
                order.GrandTotal += orderDetails.TotalAmounnt;
            }

            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<string?>> GetOfficeNumber(string officeNumber)
        {
            List<string?> officeNumbers = await _context.Customer.Where(x=> x.Office_No.ToString().Contains(officeNumber)).Select(x => x.Office_No.ToString()).ToListAsync();

            return officeNumbers;
        }

        public async Task<List<OrderDto>> VendorUSerOrderList(int Id)
        {

            var orders = await _context.Order.Where(x => x.VendorUserId == Id & x.OrderStatus == (int)OrderEnum.Pending).Select(x => new OrderDto
            {
                ID = x.ID,
                //orderDetailsListDto = x.orderDetailsList.Select(o => new OrderDetailsDto
                //{
                //    Id = o.Id,
                //    Qty = o.Qty,
                //    ProductId = o.ProductId,
                //}).ToList(),
                //customerDto = new CustomerDto
                //{
                //    Id = x.Customer.Id,
                //    Name = x.Customer.Name,
                //    Office_No = x.Customer.Office_No
                //},
                GrandTotal = x.GrandTotal,
                Gst = x.Gst
            }).ToListAsync();

            return orders;
        }
    }
}