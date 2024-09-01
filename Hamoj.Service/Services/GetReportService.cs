
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
                OrderPaymentStatus = x.OrderPaymentStatus,
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
    //public async Task<List<OrderDto>> GetCustomerReport(int customerId, DateTime fromDate, DateTime toDate)
    //{

    //    var fromMonthStart = new DateTime(fromDate.Year, fromDate.Month, 1); // Start of the from month
    //    var toMonthEnd = new DateTime(toDate.Year, toDate.Month, DateTime.DaysInMonth(toDate.Year, toDate.Month)); // End of the to month

    //    var data = await _context.Order
    //        .Where(x => (customerId == 0 ? true : x.CustomerId == customerId) &&
    //                    x.OrderStatus == (int)OrderEnum.Deliver &&
    //                    x.OrderPaymentStatus == (int)OrderPaymentStatus.Pending &&
    //                    x.Create_Date >= fromMonthStart && x.Create_Date <= toMonthEnd)
    //        .GroupBy(x => x.CustomerId)
    //        .Select(g => new OrderDto
    //        {
    //            customerDto = new CustomerDto { 
    //                Id = g.Key,
    //                Name = g.FirstOrDefault().Customer.Name
    //            },
    //            GrandTotal = g.Sum(x => x.GrandTotal),
    //        })
    //        .ToListAsync();

    //    return data;
    //}

    public async Task<List<OrderDto>> GetCustomerReport(int customerId, DateTime fromDate, DateTime toDate)
    {
        var fromMonthStart = new DateTime(fromDate.Year, fromDate.Month, 1);

        var toDateEnd = toDate.Date.AddDays(1).AddTicks(-1);

        var data = await _context.Order
            .Where(x => (customerId == 0 ? true : x.CustomerId == customerId) &&
                        x.OrderStatus == (int)OrderEnum.Deliver &&
                        x.OrderPaymentStatus == (int)OrderPaymentStatus.Pending &&
                        x.Create_Date >= fromMonthStart && x.Create_Date <= toDateEnd)
            .GroupBy(x => new { x.CustomerId, Month = new DateTime(x.Create_Date.Year, x.Create_Date.Month, 1) })
            .Select(g => new OrderDto
            {
                CustomerDto = new CustomerDto
                {
                    Id = g.Key.CustomerId,
                    Name = g.FirstOrDefault().Customer.Name
                },
                Month = g.Key.Month.ToString("MMM yyyy"),
                GrandTotal = g.Sum(x => x.GrandTotal),
            })
            .ToListAsync();

        return data;
    }


    public async Task<bool> GetOrder(int customerId, DateTime fromDate, DateTime toDate)
    {
        try
        {
            var orders = await _context.Order
                .Where(x => x.CustomerId == customerId &&
                            x.OrderStatus == (int)OrderEnum.Deliver &&
                            x.Create_Date.Date >= fromDate.Date && // Use Date property to compare only the date part
                            x.Create_Date.Date <= toDate.Date)
                .ToListAsync();

            foreach (var order in orders)
            {
                order.OrderPaymentStatus = (int)OrderPaymentStatus.Paid;
                _context.Order.Update(order);
            }

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

}
