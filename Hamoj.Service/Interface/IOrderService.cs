﻿

using Hamoj.DB.Enum;
using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IOrderService
{
    Task<List<ProductDto>> GetProductData();

    Task<bool> AddOrder(List<ProductDto> dto, int CustomerID);

    Task<List<OrderDetailsDto>> OrderList();

    Task<bool> ConfirmOrder(int ID, OrderEnum status, int qtty);

    Task<bool> AssignOrder(int OrderDetailId, int VendorUserId);

    Task<List<OrderDetailsDto>> VendorUSerOrderList(int Id);
}
