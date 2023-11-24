using Application.Categories;
using Application.Coupons;
using Application.Coupons.UserCoupons;
using Application.Products;
using AutoMapper;
using Domain;
using Domain.Product;
using Domain.Product.Category;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateProductMaps();
        CreateCategoryMaps();
        CreateCouponMaps();
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

    private void CreateCouponMaps()
    {
        CreateMap<CreateCouponRequestDTO, Coupon>();
        CreateMap<EditCouponRequestDTO, Coupon>();
        CreateMap<CreateUserCouponRequestDTO, UserCoupon>();
    }

}
