namespace ProductService.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public IEnumerable<OrderItem>? Items { get; set; }
}
