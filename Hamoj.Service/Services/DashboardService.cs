

using Hamoj.DB.Context;
using Hamoj.DB.Enum;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hamoj.Service.Services;

public class DashboardService : IDashboardService
{
	private readonly HamojDBContext _context;

	public DashboardService(HamojDBContext context)
	{
		// Set Object Value 
		_context = context;
	}

	public async Task<decimal>TotalAmount()
	{
		var data = await _context.OrderDetails.Where(x => x.OrderStatus == (int)OrderEnum.Deliver)
			.Select(x => new OrderDetailsDto
			{
				Id = x.Id,
				TotalAmounnt = x.TotalAmounnt,
			}).ToListAsync();

		var totalAmount = data.Sum(x => x.TotalAmounnt);

		return totalAmount;
	}
    public async Task<decimal> UserTotalAmount(int id)
    {

        var data = await _context.OrderDetails
            .Where(x => x.order.CustomerId == id && x.OrderStatus == (int)OrderEnum.Deliver)
            .Select(x => new OrderDetailsDto
            {
                Id = x.Id,
                TotalAmounnt = x.TotalAmounnt,
            }).ToListAsync();

        var totalAmount = data.Sum(x => x.TotalAmounnt);
        return totalAmount;
    }


}
