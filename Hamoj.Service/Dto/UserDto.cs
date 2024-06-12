
using System.ComponentModel.DataAnnotations;

namespace Hamoj.Service.Dto;

public class UserDto : BaseDto
{
    public int Id { get; set; }
    [Required (ErrorMessage ="Please Enter Name")]
    public string Name { get; set; }

    public string? MobileNumber { get; set; }

    [Required(ErrorMessage = "Please Enter Email Address")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Please Enter Password")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Confirmation Password is required.")]
    [Compare("Password", ErrorMessage = "Password and Confirmation Password Not Match.")]
    public string Confirm_Password { get; set; }

    public int Role { get; set; }
    
}
