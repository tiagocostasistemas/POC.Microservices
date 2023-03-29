using ProductService.Domain.Entities;

namespace ProductService.Data.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(Guid id);
    Task<Product> Insert(Product product);
    Task<Product> Update(Product product);
    Task Delete(Product product);
}
