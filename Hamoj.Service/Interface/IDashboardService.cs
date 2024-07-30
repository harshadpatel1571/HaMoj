using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IDashboardService
{
	Task<decimal> TotalAmount();
	Task<decimal>UserTotalAmount(int id);
}
