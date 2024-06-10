

using System.ComponentModel.DataAnnotations.Schema;

namespace Hamoj.DB.Datamodel;

public class VendorUser : basemodel
{
    public int id {  get; set; }

    
    public int VendorId { get; set; }

    public string Name { get; set;}

    public string? MobileNumber { get; set;}

    public string Username { get; set;}
    public string Password { get; set;}

    [ForeignKey(nameof(VendorId))]
    public Vendor vendor { get; set; }

    public List<OrderDetails> OrderDetailList { get; set; }

}
