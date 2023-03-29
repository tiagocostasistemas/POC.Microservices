using ProductService.Domain.Entities;

namespace ProductService.RabbitMQ;

public interface IRabbitMqService
{
    void PublishProductInserted(Product product);
    void PublishProductUpdated(Product product);
    void PublishProductDeleted(Product product);
    void PublishProductUnavailable(Guid orderId, Guid orderItemId, Guid productId);
}
