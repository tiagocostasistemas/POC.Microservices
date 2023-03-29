namespace OrderService.DTOs.Responses;

public class UpdateOrderItemResponse
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}
