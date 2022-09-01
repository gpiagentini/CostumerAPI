using AppServices.Mappers.Customer;
using AutoMapper;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
