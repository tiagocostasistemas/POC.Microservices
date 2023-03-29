using AutoMapper;
using ProductService.Data.Repositories;
using ProductService.Domain.Entities;
using ProductService.DTOs.Requests;
using ProductService.DTOs.Responses;

namespace ProductService.Application;

public class ProductApplicationService : IProductApplicationService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductApplicationService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductResponse>> GetAll()
    {
        var products = await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductResponse>>(products);
    }

    public async Task<ProductResponse> GetById(Guid id)
    {
        var product = await _productRepository.GetById(id);
        return _mapper.Map<ProductResponse>(product);
    }

    public async Task<InsertProductResponse> Insert(InsertProductRequest request)
    {
        var product = _mapper.Map<Product>(request);
        product = await _productRepository.Insert(product);
        return _mapper.Map<InsertProductResponse>(product);
    }

    public async Task<UpdateProductResponse> Update(UpdateProductRequest request)
    {
        var product = _mapper.Map<Product>(request);
        product = await _productRepository.Update(product);
        return _mapper.Map<UpdateProductResponse>(product);
    }

    public async Task Delete(Guid id)
    {
        var product = await _productRepository.GetById(id);
        await _productRepository.Delete(product);
    }
}
