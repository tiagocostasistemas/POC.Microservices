using OrderService.Domain.Enums;

namespace OrderService.Domain.Entities;

public class OrderItem
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public EOrderItemStatus Status { get; set; }
}
