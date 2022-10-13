using AppServices.Mappers.Product.Requests;
using AppServices.Mappers.Product.Responses;
using AutoMapper;
using DomainModels;
using System;

namespace AppServices.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductResponse>()
                .ForMember(dst => dst.ExpirationAt, map => map.MapFrom(src => src.ExpirationAt.ToString("dd/MM/yyyy")))
                .ForMember(dst => dst.ProductType, map => map.MapFrom(src => Enum.GetName(typeof(ProductType), src.Type)));

            CreateMap<NewProductRequest, Product>()
                .ForMember(dst => dst.IssuanceAt, map => map.MapFrom(src => Convert.ToDateTime(src.ExpirationAt)))
                .ForMember(dst => dst.ExpirationAt, map => map.MapFrom(src => Convert.ToDateTime(src.ExpirationAt)))
                .ForMember(dst => dst.DaysToExpire, map => map.MapFrom(src => src.ExpirationAt.Subtract(DateTime.Now).Days));
        }
    }
}
