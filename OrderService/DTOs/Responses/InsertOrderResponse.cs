namespace OrderService.DTOs.Responses;

public class InsertOrderResponse
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<InsertOrderItemResponse>? Items { get; set; }
}
