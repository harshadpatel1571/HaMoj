
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamoj.Service.Dto;

public class OrderDto : BaseDto
{
    public int ID { get; set; }
    public int VendorID { get; set; }
    public int CustomerId { get; set; }
    public int? VendorUserId { get; set; }
    public decimal Gst { get; set; }
    public decimal GrandTotal { get; set; }
    public int OrderStatus { get; set; }
    public string UserName { get; set; }
    [ForeignKey(nameof(VendorUserId))]
    public VendorDto vendorDto { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public CustomerDto CustomerDto { get; set; }
    [ForeignKey(nameof(VendorID))]

    public VendorUserDto? vendorUserDto { get; set; }
    public List<OrderDetailsDto> orderDetailsListDto { get; set; }


    public string? Month { get; set; }
}
public class CustomerProductOrder
{
    public int Id { get; set; }
    public int Qtty { get; set; }
}
