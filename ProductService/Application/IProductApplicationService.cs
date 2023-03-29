using ProductService.DTOs.Requests;
using ProductService.DTOs.Responses;

namespace ProductService.Application;

public interface IProductApplicationService
{
    Task<IEnumerable<ProductResponse>> GetAll();
    Task<ProductResponse> GetById(Guid id);
    Task<InsertProductResponse> Insert(InsertProductRequest request);
    Task<UpdateProductResponse> Update(UpdateProductRequest request);
    Task Delete(Guid id);
}
