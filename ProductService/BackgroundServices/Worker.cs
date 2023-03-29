using ProductService.RabbitMQ;

namespace ProductService.BackgroundServices;

public class Worker : BackgroundService
{
    private readonly RabbitMqClient _rabbitMqClient;

    public Worker(RabbitMqClient rabbitMqClient)
    {
        _rabbitMqClient = rabbitMqClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var messages = _rabbitMqClient.Consume("order-inserted");
            await Task.Delay(1000, stoppingToken);
        }
    }
}
