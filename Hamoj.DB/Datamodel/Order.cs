using System.ComponentModel.DataAnnotations.Schema;

namespace Hamoj.DB.Datamodel;

public class Order : basemodel
{
    public int ID { get; set; }
    public int VendorID { get; set; }
    public int CustomerId { get; set; }
    public int? VendorUserId { get; set; }
    public decimal Gst { get; set; }
    public decimal GrandTotal { get; set; }
    public int OrderStatus { get; set; }
    public int OrderPaymentStatus { get; set; }
    [ForeignKey(nameof(VendorID))]
    public Vendor vendor { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; }

    public List<OrderDetails> orderDetailsList { get; set; }

    [ForeignKey(nameof(VendorUserId))]
    public VendorUser? vendorUser { get; set; }

}
