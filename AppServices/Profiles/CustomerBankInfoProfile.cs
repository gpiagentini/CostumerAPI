using AutoMapper;
using DomainModels;
using AppServices.Mappers.CustomerBankInfo.Responses;

namespace AppServices.Profiles
{
    public class CustomerBankInfoProfile : Profile
    {
        public CustomerBankInfoProfile()
        {
            CreateMap<CustomerBankInfo, GetBankInfoResponse>();

            CreateMap<CustomerBankInfo, GetBankInfoWithCustomerResponse>()
                .ForMember(dist => dist.AccountBallance, map => map.MapFrom(src => src.AccountBalance))
                .ForMember(dist => dist.CustomerId, map => map.MapFrom(src => src.CustomerId))
                .ForMember(dist => dist.CustomerName, map => map.MapFrom(src => src.Customer.FullName))
                .ForMember(dist => dist.CustomerCpf, map => map.MapFrom(src => src.Customer.Cpf));
        }

    }
}
