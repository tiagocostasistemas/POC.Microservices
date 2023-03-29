using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;

namespace ProductService.Data.Contexts;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    { }

    public DbSet<Product> Products { get; set; }
}
