namespace OrderService.DTOs.Responses;

public class UpdateOrderResponse
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<UpdateOrderItemResponse>? Items { get; set; }
}
