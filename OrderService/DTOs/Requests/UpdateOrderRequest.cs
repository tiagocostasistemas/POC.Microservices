namespace OrderService.DTOs.Requests;

public class UpdateOrderRequest
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<UpdateOrderItemRequest>? Items { get; set; }
}
