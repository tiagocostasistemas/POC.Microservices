using RabbitMQ.Client;
using System.Text;

namespace OrderService.RabbitMQ;

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


}
