
using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IGetReportService
{
    Task<List<OrderDto>> GetReportAsync(int customerId);

    Task<OrderDetailsDto> GetOrderDetails(int orderId);


}
