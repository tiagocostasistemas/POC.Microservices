namespace ProductService.DTOs.Requests;

public class InsertProductRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }

}
