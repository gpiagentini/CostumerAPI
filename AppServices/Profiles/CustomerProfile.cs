using AppServices.Mappers.Customer;
using AutoMapper;
using DomainModels;

namespace AppServices.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerRequest, CustomerBase>();
            CreateMap<CustomerBase, GetCustomerResponse>();
            CreateMap<UpdateCustomerRequest, CustomerBase>();
        }
    }
}
