namespace OrderService.DTOs.Responses;

public class OrderResponse
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<OrderItemResponse>? Items { get; set; }
}
