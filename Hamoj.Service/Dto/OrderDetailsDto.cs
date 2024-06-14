﻿

using Hamoj.DB.Datamodel;

namespace Hamoj.Service.Dto;

public class OrderDetailsDto:BaseDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int? VendorUserId { get; set; }
    public int Qty { get; set; }
    public decimal Amount { get; set; }
    public decimal TotalAmounnt { get; set; }
    public int OrderStatus { get; set; }
    public OrderDto orderDto { get; set; }
    public ProductDto productDto { get; set; }
    public CustomerDto customerDto { get; set; }
    public VendorUserDto? vendorUserDto { get; set; }
    public List<ProductDto> productDtoList { get; set; }
}
