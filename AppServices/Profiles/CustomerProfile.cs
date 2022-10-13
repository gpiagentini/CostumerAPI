using AppServices.Mappers.Customer.Requests;
using AppServices.Mappers.Customer.Responses;
using AutoMapper;
using DomainModels;

namespace AppServices.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerRequest, CustomerBase>();

            CreateMap<CustomerBase, GetCustomerResponse>()
                .ForMember(dst => dst.AccountBalance, map => map.MapFrom(src => src.BankInfo.AccountBalance));

            CreateMap<UpdateCustomerRequest, CustomerBase>();
        }
    }
}
