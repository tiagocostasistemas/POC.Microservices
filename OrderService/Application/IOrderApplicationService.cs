using OrderService.DTOs.Requests;
using OrderService.DTOs.Responses;

namespace OrderService.Application;

public interface IOrderApplicationService
{
    Task<IEnumerable<OrderResponse>> GetAll();
    Task<OrderResponse> GetById(Guid id);
    Task<InsertOrderResponse> Insert(InsertOrderRequest request);
    Task<UpdateOrderResponse> Update(UpdateOrderRequest request);
    Task Delete(Guid id);
}
