﻿namespace ProductService.DTOs.Requests;

public class UpdateProductRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}
