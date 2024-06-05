

using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IOrderService
{
    Task<List<ProductDto>> GetProductData();

    Task<bool> AddOrder(List<CustomerProductOrder> dto,int CustomerID);

    Task<List<OrderDetailsDto>> OrderList ();

    Task<OrderDto> ConfirmOrder(int ID);

    Task<OrderDto> UpdateOrder(OrderDto order);

}
