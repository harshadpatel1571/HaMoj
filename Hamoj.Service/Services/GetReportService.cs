
using Hamoj.DB.Context;
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
            .Where(x => x.CustomerId == customerId && x.OrderStatus == (int)OrderEnum.Deliver &&
                    fromDate.Date <= x.Create_Date.Date && toDate.Date >= x.Create_Date.Date)
            .Select(x => new OrderDto
            {
                ID = x.ID,
                Create_Date = x.Create_Date,
                GrandTotal = x.GrandTotal,
            }).ToListAsync();

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
}
