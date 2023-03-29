using Microsoft.EntityFrameworkCore;
using ProductService.Data.Contexts;
using ProductService.Domain.Entities;

namespace ProductService.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAll() => await GetAllProducts();

    public async Task<Product> GetById(Guid id)
    {
        var products = await GetAllProducts();
        return products.Where(product => product.Id.Equals(id)).FirstOrDefault()!;
    }
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> Insert(Product product)
    {
        product.Id = Guid.NewGuid();
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Update(Product product)
    {
        _context.Attach(product);
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return product;

    }

    public async Task Delete(Product product)
    {
        _context.Remove(product);
        await _context.SaveChangesAsync();
    }
}
