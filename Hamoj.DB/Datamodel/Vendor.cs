

using System.ComponentModel.DataAnnotations;

namespace Hamoj.DB.Datamodel;

public class Vendor : basemodel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Email { get; set; }

    public string MobileNumber { get; set; }


    public string Address { get; set; }

    public List<Order> orderList { get; set; }

    public List<VendorUser> vendorUsers { get; set; }

    public string Password { get; set; }

}
