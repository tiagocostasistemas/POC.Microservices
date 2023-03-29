using Newtonsoft.Json;
using ProductService.Domain.Entities;
using ProductService.RabbitMQ;

namespace ProductService.BackgroundServices;

public class RabbitMqBackgroundService : IRabbitMqBackgroundService
{
    private readonly RabbitMqClient _rabbitMqClient;

    public RabbitMqBackgroundService(RabbitMqClient rabbitMqClient)
    {
        _rabbitMqClient = rabbitMqClient;
    }

    public IEnumerable<Order>? ConsumeOrdersInserted()
    {
        var messages = _rabbitMqClient.Consume("order-inserted");
        var message = GetMessage(messages);
        return GetOrders(message);
    }

    private string GetMessage(IEnumerable<string> messages)
    {
        return JsonConvert.SerializeObject(messages);
    }
    private IEnumerable<Order>? GetOrders(string message)
    {
        return JsonConvert.DeserializeObject<IEnumerable<Order>>(message);
    }
}
