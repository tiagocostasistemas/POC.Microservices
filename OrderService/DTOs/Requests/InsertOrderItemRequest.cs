namespace OrderService.DTOs.Requests;

public class InsertOrderItemRequest
{
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}
