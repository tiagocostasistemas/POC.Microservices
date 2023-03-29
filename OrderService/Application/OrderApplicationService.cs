using AutoMapper;
using OrderService.Data.Repositories;
using OrderService.Domain.Entities;
using OrderService.DTOs.Requests;
using OrderService.DTOs.Responses;
using OrderService.RabbitMQ.Services;

namespace OrderService.Application;

public class OrderApplicationService : IOrderApplicationService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IRabbitMqService _rabbitMqService;

    public OrderApplicationService(IOrderRepository orderRepository, IMapper mapper, IRabbitMqService rabbitMqService)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _rabbitMqService = rabbitMqService;
    }

    public async Task<IEnumerable<OrderResponse>> GetAll()
    {
        var orders = await _orderRepository.GetAll();
        return _mapper.Map<IEnumerable<OrderResponse>>(orders);
    }

    public async Task<OrderResponse> GetById(Guid id)
    {
        var order = await _orderRepository.GetById(id);
        return _mapper.Map<OrderResponse>(order);
    }

    public async Task<InsertOrderResponse> Insert(InsertOrderRequest request)
    {
        var order = _mapper.Map<Order>(request);
        order = await _orderRepository.Insert(order);

        _rabbitMqService.PublishOrderInserted(order);

        return _mapper.Map<InsertOrderResponse>(order);
    }

    public async Task<UpdateOrderResponse> Update(UpdateOrderRequest request)
    {
        var order = _mapper.Map<Order>(request);
        order = await _orderRepository.Update(order);

        _rabbitMqService.PublishOrderUpdated(order);

        return _mapper.Map<UpdateOrderResponse>(order);
    }

    public async Task Delete(Guid id)
    {
        var order = await _orderRepository.GetById(id);
        await _orderRepository.Delete(order);

        _rabbitMqService.PublishOrderDeleted(order);
    }
}
