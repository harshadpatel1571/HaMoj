﻿
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Hamoj.Service.Dto;

public class CategoryDto:BaseDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required !")]
    public string Name { get; set; }
    public string? Image { get; set; }

    [RegularExpression(@"([a-zA-Z0-9\s_\\.\-():])+(.jpg|.jpeg|.png|.webp)$", ErrorMessage = "Only JPG, JPEG, PNG, and WEBP images are allowed.")]
    public IFormFile? Imagefile { get; set; }

    //public ProductDto ProductDtoList { get; set; }
}
