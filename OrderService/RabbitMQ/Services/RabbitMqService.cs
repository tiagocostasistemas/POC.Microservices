using Newtonsoft.Json;
using OrderService.Domain.Entities;

namespace OrderService.RabbitMQ.Services;

public class RabbitMqService : IRabbitMqService
{
    private readonly RabbitMqClient _rabbitMqClient;

    public RabbitMqService(RabbitMqClient rabbitMqClient)
    {
        _rabbitMqClient = rabbitMqClient;
    }

    public void PublishOrderInserted(Order order)
    {
        var message = GetMessage(order);
        _rabbitMqClient.Publish("order-inserted", message);
    }

    public void PublishOrderUpdated(Order order)
    {
        var message = GetMessage(order);
        _rabbitMqClient.Publish("order-updated", message);
    }

    public void PublishOrderDeleted(Order order)
    {
        var message = GetMessage(order);
        _rabbitMqClient.Publish("order-deleted", message);
    }
    private string GetMessage(Order order)
    {
        return JsonConvert.SerializeObject(order);
    }
}
