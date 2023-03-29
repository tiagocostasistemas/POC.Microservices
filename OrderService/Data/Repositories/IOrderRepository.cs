using OrderService.Domain.Entities;

namespace OrderService.Data.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAll();
    Task<Order> GetById(Guid id);
    Task<Order> Insert(Order order);
    Task<Order> Update(Order order);
    Task Delete(Order order);
    Task<OrderItem> GetOrderItemById(Guid orderItemId);
    Task UpdateOrderItem(OrderItem orderItem);
}
