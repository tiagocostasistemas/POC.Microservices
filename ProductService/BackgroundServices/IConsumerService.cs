namespace ProductService.BackgroundServices;

public interface IConsumerService
{
    Task ConsumeOrders();
}
