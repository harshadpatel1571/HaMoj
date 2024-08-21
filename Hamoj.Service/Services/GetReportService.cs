﻿
using Hamoj.DB.Context;
using Hamoj.DB.Datamodel;
using Hamoj.DB.Enum;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hamoj.Service.Services;

public class GetReportService : IGetReportService
{
    private readonly HamojDBContext _context;

    public GetReportService(HamojDBContext context)
    {
        _context = context;
    }

    public async Task<List<OrderDto>> GetReportAsync(int customerId, DateTime fromDate, DateTime toDate)
    {
        var orderDetails = await _context.Order
            .Where(x => x.CustomerId == customerId &&
                        x.OrderStatus == (int)OrderEnum.Deliver &&
                        fromDate.Date <= x.Create_Date.Date &&
                        toDate.Date >= x.Create_Date.Date)
            .Select(x => new OrderDto
            {
                ID = x.ID,
                Create_Date = x.Create_Date,
                GrandTotal = x.GrandTotal,
                UserName = x.VendorUserId != null ? x.vendorUser.Name : x.vendor.Name
            })
            .ToListAsync();

        return orderDetails;
    }




    public async Task<List<OrderDetailsDto>> GetOrderDetails(int orderId)
    {
        var orderDetails = await _context.OrderDetails.Where(x => x.OrderId == orderId).Select(x => new OrderDetailsDto
        {
            Id = x.Id,
            OrderId = x.OrderId,
            productDto = new ProductDto
            {
                Id = x.ProductId,
                Name = x.product.Name,

            },
            Qty = x.Qty,
            TotalAmounnt = x.TotalAmounnt,
            Amount = x.Amount,

        }).ToListAsync();

        return orderDetails;
    }
    public async Task<List<OrderDto>> GetCustomerReport(int customerId)
    {
        var data = await _context.Order
            .Where(x => x.CustomerId == customerId &&
                        x.OrderStatus == (int)OrderEnum.Deliver && x.OrderPaymentStatus == (int)OrderPaymentStatus.Pending)
            .Select(x => new OrderDto
            {
                Create_Date = x.Create_Date,
                GrandTotal = x.GrandTotal,
             
            })
            .ToListAsync();

        return data;
    }

    public async Task<bool> GetOrder(int customerId)
    {
        try
        {
            var order = await _context.Order.Where(x => x.CustomerId == customerId &&
            x.OrderStatus == (int)OrderEnum.Deliver).ToListAsync();
            foreach (var orders in order)
            {
                orders.OrderPaymentStatus = (int)OrderPaymentStatus.Paid;
            }

            _context.Order.UpdateRange(order);
            await _context.SaveChangesAsync();
            return true;
        }
        catch(Exception )
        {
            return false;
        }
    }
}
