
using Hamoj.DB.Context;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hamoj.Service.Services;

public class GetReportService : IGetReportService
{
    private readonly HamojDBContext _context;

    public GetReportService(HamojDBContext context)
    {
        // Set Object Value 
        _context = context;
    }

    public async Task<List<OrderDto>> GetReportAsync(int customerId)
    {
        return await _context.Order.Where(x => x.CustomerId == customerId).Select(x => new OrderDto
        {
            ID = x.ID,
            Create_Date = x.Create_Date,
            GrandTotal = x.GrandTotal,
        }).ToListAsync();
    }

    public async Task<OrderDetailsDto> GetOrderDetails(int orderId)
    {
        var orderDetails = await _context.OrderDetails.Where(x => x.OrderId == orderId).Select(x => new OrderDetailsDto
        {
            Id = x.Id,
            OrderId = x.OrderId,
            productDto = new ProductDto
            {
                Id =x.ProductId,
                Name = x.product.Name,

            },
            Qty = x.Qty,
            TotalAmounnt = x.TotalAmounnt,
            Amount = x.Amount,

        }).FirstOrDefaultAsync();
            

        return orderDetails;
    }
}
