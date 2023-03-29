using Newtonsoft.Json;
using ProductService.Domain.Entities;

namespace ProductService.RabbitMQ;

public class RabbitMqService : IRabbitMqService
{
    private readonly RabbitMqClient _rabbitMqClient;

    public RabbitMqService(RabbitMqClient rabbitMqClient)
    {
        _rabbitMqClient = rabbitMqClient;
    }

    public void PublishProductInserted(Product product)
    {
        var message = GetMessage(product);
        _rabbitMqClient.Publish("product-inserted", message);
    }

    public void PublishProductUpdated(Product product)
    {
        var message = GetMessage(product);
        _rabbitMqClient.Publish("product-updated", message);
    }

    public void PublishProductDeleted(Product product)
    {
        var message = GetMessage(product);
        _rabbitMqClient.Publish("product-deleted", message);
    }

    public void PublishProductUnavailable(Guid orderId, Guid orderItemId, Guid productId)
    {
        var model = new
        {
            OrdeId = orderId,
            OrderItemId = orderItemId,
            ProductId = productId
        };

        var message = GetMessage(model);
        _rabbitMqClient.Publish("product-unavailable", message);
    }
   
    private string GetMessage(Product product)
    {
        return JsonConvert.SerializeObject(product);
    }

    private string GetMessage(object model)
    {
        return JsonConvert.SerializeObject(model);
    }
}
