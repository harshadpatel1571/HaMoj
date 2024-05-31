

using System.ComponentModel.DataAnnotations;

namespace Hamoj.Service.Dto;

public class LoginDto : BaseDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please Enter Email Address")]
    public string Email { get; set; }
  
    [Required(ErrorMessage = "Please Enter Password")]
    public string Password { get; set; }
}
