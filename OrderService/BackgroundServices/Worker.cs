using Newtonsoft.Json;
using OrderService.Domain.Entities;
using OrderService.RabbitMQ.Messages;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace OrderService.BackgroundServices;

public class Worker : BackgroundService
{
    private const string HOST_NAME = "rabbitmq";

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var messages = Consume("product-unavailable");
            var message = GetMessage(messages);
            var products = GetProductsUnavailable(message);
            foreach (var product in products!)
                CancelOrderItem(product);

            await Task.Delay(1000, stoppingToken);
        }
    }

    private void CancelOrderItem(ProductUnavailableMessage message)
    {

    }

    public IEnumerable<string> Consume(string queue)
    {
        var messages = new List<string>();
        var factory = new ConnectionFactory() { HostName = HOST_NAME };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: queue, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                messages.Add(message);
            };

            channel.BasicConsume(queue: queue, autoAck: false, consumer: consumer);

            return messages;
        }
    }

    private string GetMessage(IEnumerable<string> messages)
    {
        return JsonConvert.SerializeObject(messages);
    }

    private IEnumerable<ProductUnavailableMessage>? GetProductsUnavailable(string message)
    {
        return JsonConvert.DeserializeObject<IEnumerable<ProductUnavailableMessage>>(message);
    }
}
