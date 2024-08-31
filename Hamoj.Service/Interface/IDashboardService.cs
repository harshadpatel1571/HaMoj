using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IDashboardService
{
	Task<decimal> TotalPaidAmount();
	Task<decimal> TotalPendingAmount();
	Task<decimal>UserTotalAmount(int id);
}
