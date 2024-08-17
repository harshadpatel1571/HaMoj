

using System.ComponentModel.DataAnnotations;

namespace Hamoj.Service.Dto;

public class LoginDto
{
    //public int Id { get; set; }

    [Required(ErrorMessage = "Please Enter Mobile Number")]
    public string MobileNumber { get; set; }
  
    [Required(ErrorMessage = "Please Enter Password")]
    public string Password { get; set; }
    public bool? IsVendor { get; set; }
}

public class UserLoginDto : BaseDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please Enter Email Address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please Enter Password")]
    public string Password { get; set; }

}