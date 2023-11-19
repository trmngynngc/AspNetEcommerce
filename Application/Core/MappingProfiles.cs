using AutoMapper;
using Domain.Product;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateProductMaps();
    }

    private void CreateProductMaps()
    {
        CreateMap<CreateProductRequestDTO, Product>();
        CreateMap<EditProductRequestDTO, Product>();
    }
}