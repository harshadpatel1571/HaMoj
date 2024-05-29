

using System.ComponentModel.DataAnnotations;

namespace Hamoj.DB.Datamodel;

public class Vendor : basemodel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required !")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Email is required !")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Phone Number is required !")]
    public string Phone { get; set; }
    [Required(ErrorMessage = "Contact Phone Number is required !")]
    public string Contact_Phone { get; set; }
    [Required(ErrorMessage = "Address is required !")]
    public string Address { get; set; }

    public List<Order> orderList { get; set; }

}
