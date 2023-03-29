namespace OrderService.DTOs.Requests;

public class InsertOrderRequest
{
    public DateTime Date { get; set; }
    public IEnumerable<InsertOrderItemRequest>? Items { get; set; }
}
