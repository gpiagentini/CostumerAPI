using AppServices.Mappers.Portfolio.Requests;
using AutoMapper;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<InvestmentRequest, Order>()
                .ForMember(dst => dst.NetValue, map => map.MapFrom(src => src.Quotes * src.UnitPrice));
        }
    }
}
