using OrderService.Domain.Entities;

namespace OrderService.RabbitMQ.Services;

public interface IRabbitMqService
{
    void PublishOrderInserted(Order order);
    void PublishOrderUpdated(Order order);
    void PublishOrderDeleted(Order order);
}