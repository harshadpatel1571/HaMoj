
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
    //public VendorDto vendorDto { get; set; }
    //public CustomerDto customerDto { get; set; }
    //public VendorUserDto? vendorUserDto { get; set; }
    //public List<OrderDetailsDto> orderDetailsListDto { get; set; }


}
public class CustomerProductOrder
{
    public int Id { get; set; }
    public int Qtty { get; set; }
}
