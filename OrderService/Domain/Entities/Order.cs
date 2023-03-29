namespace OrderService.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<OrderItem>? Items { get; set; }

}
