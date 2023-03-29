using AutoMapper;
using ProductService.Domain.Entities;
using ProductService.DTOs.Requests;
using ProductService.DTOs.Responses;

namespace ProductService.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResponse>();
        CreateMap<Product, InsertProductResponse>();
        CreateMap<Product, UpdateProductResponse>();
        CreateMap<InsertProductRequest, Product>();
        CreateMap<UpdateProductRequest, Product>();
    }
}
