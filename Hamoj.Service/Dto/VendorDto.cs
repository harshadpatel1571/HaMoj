using System.ComponentModel.DataAnnotations;

namespace Hamoj.Service.Dto;

public class VendorDto : BaseDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please Enter Name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please Enter Email Address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please Enter Phone Number")]
    public string MobileNumber { get; set; }

    [Required(ErrorMessage = "Please Enter Address")]
    public string Address { get; set; }

    //public OrderDto orderDtoList { get; set; }

    //public VendorUserDto vendorUserDtoList { get; set; }

    [Required(ErrorMessage = "Please Enter Password")]
    public string Password { get; set; }
}
