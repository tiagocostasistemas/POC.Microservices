using AutoMapper;
using OrderService.Domain.Entities;
using OrderService.DTOs.Requests;
using OrderService.DTOs.Responses;

namespace OrderService.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateOrderMap();
        CreateOrderItemMap();
    }

    private void CreateOrderMap()
    {
        CreateMap<Order, OrderResponse>();
        CreateMap<Order, InsertOrderResponse>();
        CreateMap<Order, UpdateOrderResponse>();
        CreateMap<InsertOrderRequest, Order>();
        CreateMap<UpdateOrderRequest, Order>();
    }

    private void CreateOrderItemMap()
    {
        CreateMap<OrderItem, OrderItemResponse>();
        CreateMap<OrderItem, InsertOrderItemResponse>();
        CreateMap<OrderItem, UpdateOrderItemResponse>();
        CreateMap<InsertOrderItemRequest, OrderItem>();
        CreateMap<UpdateOrderItemRequest, OrderItem>();
    }
}
