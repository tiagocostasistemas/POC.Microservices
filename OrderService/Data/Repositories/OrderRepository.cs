using Microsoft.EntityFrameworkCore;
using OrderService.Data.Context;
using OrderService.Domain.Entities;

namespace OrderService.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _context;

    public OrderRepository(OrderContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAll() => await GetAllOrders();

    public async Task<Order> GetById(Guid id)
    {
        var orders = await GetAllOrders();
        return orders.Where(order => order.Id.Equals(id)).FirstOrDefault()!;
    }

    private async Task<IEnumerable<Order>> GetAllOrders()
    {
        return await _context.Orders.Include(order => order.Items).ToListAsync();
    }

    public async Task<Order> Insert(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order> Update(Order order)
    {
        _context.Attach(order);
        _context.Entry(order).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task Delete(Order order)
    {
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public Task<OrderItem> GetOrderItemById(Guid orderItemId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrderItem(OrderItem orderItem)
    {
        throw new NotImplementedException();
    }
}
