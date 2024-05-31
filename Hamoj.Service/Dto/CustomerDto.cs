

using System.ComponentModel.DataAnnotations;

namespace Hamoj.Service.Dto;

public class CustomerDto : BaseDto
{
    public int Id { get; set; }
    public string? CompanyName { get; set; }

    public int? Office_No { get; set; }

    public string Name { get; set; }
    public string? Email { get; set; }
    public string Mobile { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public int? Pincode { get; set; }

    [Required(ErrorMessage = "Password Is required !")]
    public String Password { get; set; }

    public OrderDto OrderDtoList { get; set; }


}
