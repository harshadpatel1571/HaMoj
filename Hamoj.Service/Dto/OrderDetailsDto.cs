

using Hamoj.DB.Datamodel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamoj.Service.Dto;

public class OrderDetailsDto : BaseDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Qty { get; set; }
    public decimal Amount { get; set; }
    public decimal TotalAmounnt { get; set; }
    public int OrderStatus { get; set; }
    [ForeignKey(nameof(OrderId))]

    public OrderDto orderDto { get; set; }
    [ForeignKey(nameof(ProductId))]

    public ProductDto productDto { get; set; }
    public CustomerDto customerDto { get; set; }
    public List<ProductDto> productDtoList { get; set; }
}
