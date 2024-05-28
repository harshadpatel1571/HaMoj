
using Microsoft.AspNetCore.Http;

namespace Hamoj.Service.Dto;

public class CategoryDto:BaseDto
{
    public int Id { get; set; } 

    public string Name { get; set; }

    public string? Image { get; set; }

    public IFormFile? Imagefile { get; set; }
}
