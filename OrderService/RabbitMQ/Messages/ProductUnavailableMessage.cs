namespace OrderService.RabbitMQ.Messages;

public class ProductUnavailableMessage
{
    public Guid OrderId { get; set; }
    public Guid OrderItemId { get; set; }
    public Guid ProductId { get; set; }
}
