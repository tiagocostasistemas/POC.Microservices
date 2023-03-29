using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ProductService.RabbitMQ;

public class RabbitMqClient
{
    private const string HOST_NAME = "rabbitmq";
    public void Publish(string queue, string message)
    {
        var factory = new ConnectionFactory() { HostName = HOST_NAME };
        using (var connection = factory.CreateConnection())
        {
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queue, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "", routingKey: queue, basicProperties: null, body: body);

            channel.Close();
            connection.Close();
        }
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
}

