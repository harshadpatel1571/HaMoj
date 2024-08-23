
using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IGetReportService
{
    Task<List<OrderDto>> GetReportAsync(int customerId, DateTime fromDate, DateTime toDate);

    Task<List<OrderDetailsDto>> GetOrderDetails(int orderId);
    Task<List<OrderDto>> GetCustomerReport(int customerID, DateTime fromDate , DateTime toDate);
    Task<bool> GetOrder(int customerID, DateTime fromDate, DateTime toDate);


}
