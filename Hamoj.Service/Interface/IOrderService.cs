

using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IOrderService
{
    Task<List<ProductDto>> GetProductData();

    Task<bool> AddOrder(List<CustomerProductOrder> dto,int CustomerID);

}
