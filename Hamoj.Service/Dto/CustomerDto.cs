

using System.ComponentModel.DataAnnotations;

namespace Hamoj.Service.Dto;

public class CustomerDto : BaseDto
{
    public int Id { get; set; }
    public string? CompanyName { get; set; }
    [Required(ErrorMessage = "Office Number  Is required !")]
    public int? Office_No { get; set; }
    [Required(ErrorMessage = "Name is required !")]

    public string Name { get; set; }
    [Required(ErrorMessage = "Email is required !")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Mobile Number Is required !")]
    public string Mobile { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public int? Pincode { get; set; }

    [Required(ErrorMessage = "Password Is required !")]
    public String Password { get; set; }

    public OrderDto OrderDtoList { get; set; }

    public OrderDetailsDto OrderDetailsDtoList { get; set; }
}
