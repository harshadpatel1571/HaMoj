

using System.ComponentModel.DataAnnotations;

namespace Hamoj.Service.Dto;

public class LoginDto : BaseDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please Enter Mobile Number Address")]
    public string MobileNumber { get; set; }
  
    [Required(ErrorMessage = "Please Enter Password")]
    public string Password { get; set; }

    public bool? IsVendor { get; set; }
}

//public class CustomerLoginDto : BaseDto
//{
//    public int Id { get; set; }

//    [Required(ErrorMessage = "Please Enter Mobile Number Address")]
//    public string MobileNumber { get; set; }

//    [Required(ErrorMessage = "Please Enter Password")]
//    public string Password { get; set; }

//}