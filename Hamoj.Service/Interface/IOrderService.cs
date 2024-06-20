

using Hamoj.DB.Enum;
using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IOrderService
{
    Task<List<ProductDto>> GetProductData();

    Task<bool> AddOrder(List<ProductDto> dto, int CustomerID);

    Task<List<OrderDto>> OrderList();

    Task<bool> ConfirmOrder(int ID, OrderEnum status, List<OrderDataDto> qty);

    Task<bool> AssignOrder(int OrderDetailId, int VendorUserId);

    Task<List<OrderDto>> VendorUSerOrderList(int Id);

   

}
