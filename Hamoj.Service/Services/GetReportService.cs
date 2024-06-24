
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
        return await _context.Order.Where(x => x.CustomerId == 1).Select(x => new OrderDto
        {
            ID = x.ID,
            Create_Date = x.Create_Date,
            GrandTotal = x.GrandTotal,
        }).ToListAsync();
    }

}
