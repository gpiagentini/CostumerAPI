using AppServices.Mappers.Portfolio.Requests;
using AppServices.Mappers.Portfolio.Responses;
using AutoMapper;
using DomainModels;
using System.Linq;

namespace AppServices.Profiles
{
    public class PortfolioProfile : Profile
    {
        public PortfolioProfile()
        {
            CreateMap<CreateNewPortfolioRequest, Portfolio>()
                .ForMember(dst => dst.CustomerId, map => map.MapFrom(src => src.CustomerId));

            CreateMap<Portfolio, GetPortfolioByIdPortfolioResponse>()
                .ForMember(dst => dst.ProductSymbols, map => map.MapFrom(src => src.Products.Select(product => product.Symbol)));
        }
    }
}
