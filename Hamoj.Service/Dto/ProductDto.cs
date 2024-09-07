﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamoj.Service.Dto;

public class ProductDto :BaseDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please Select Category !")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Name is required !")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Product Price is required !")]
    public int Price { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    [RegularExpression(@"([a-zA-Z0-9\s_\\.\-():])+(.jpg|.jpeg|.png|.webp)$", ErrorMessage = "Only JPG, JPEG, PNG, and WEBP images are allowed.")]
    public IFormFile? Imagefile { get; set; }

    public CategoryDto CategoryDto { get; set; }

    public OrderDetailsDto orderDetailsListDto { get; set; }

    public GetOrderDetailsDto getOrderDetailsDto { get; set; }
    public int Qty { get; set; }

    public int Office_no { get; set; }
}


public class ProductOrderDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
}