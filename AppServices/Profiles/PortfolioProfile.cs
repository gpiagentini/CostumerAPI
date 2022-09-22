using AppServices.Mappers.Portfolio.Requests;
using AppServices.Mappers.Portfolio.Responses;
using AutoMapper;
using DomainModels;

namespace AppServices.Profiles
{
    public class PortfolioProfile : Profile
    {
        public PortfolioProfile()
        {
            CreateMap<CreateNewPortfolioRequest, Portfolio>()
                .ForMember(dst => dst.CustomerId, map => map.MapFrom(src => src.CustomerId));

            CreateMap<Portfolio, GetPortfolioByIdPortfolioResponse>();
        }
    }
}
