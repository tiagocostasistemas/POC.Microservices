using ProductService.Domain.Entities;

namespace ProductService.BackgroundServices;

public interface IRabbitMqBackgroundService
{
    IEnumerable<Order>? ConsumeOrdersInserted();
}
