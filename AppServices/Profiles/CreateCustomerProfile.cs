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
    public class CreateCustomerProfile : Profile
    {
        public CreateCustomerProfile()
        {
            CreateMap<CreateCustomerRequest, CustomerBase>();
            CreateMap<CreateCustomerRequest, GetCustomerProfile>();
        }
    }
}
