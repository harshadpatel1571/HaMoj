

using System.ComponentModel.DataAnnotations;

namespace Hamoj.Service.Dto;

public class VendorUserDto : BaseDto
{
    public int id { get; set; }

    public int VendorId { get; set; }

    [Required(ErrorMessage = "Name is reqired")]
    public string Name { get; set; }

    public string? MobileNumber { get; set; }

    [Required(ErrorMessage = "Username is reqired")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is reqired")]
    public string Password { get; set; }

    //public VendorDto vendorDto { get; set; }

    //public OrderDto orderDtoList { get; set; }
}
