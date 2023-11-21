using Application.Categories;
using Application.Products;
using AutoMapper;
using Domain.Product;
using Domain.Product.Category;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateProductMaps();
        CreateCategoryMaps();
    }

    private void CreateProductMaps()
    {
        CreateMap<CreateProductRequestDTO, Product>();
        CreateMap<EditProductRequestDTO, Product>();
    }

    private void CreateCategoryMaps()
    {
        CreateMap<CreateCategoryRequestDTO, Category>();
        CreateMap<EditProductRequestDTO, Category>();
    }
}
