using AppServices.Interfaces;
using AppServices.Mappers.CustomerBankInfo.Responses;
using AutoMapper;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public class CustomerBankInfoAppService : ICustomerBankInfoAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerBankInfoService _customerBankInfoService;

        public CustomerBankInfoAppService(ICustomerBankInfoService customerBankInfoService,
            IMapper mapper)
        {
            _customerBankInfoService = customerBankInfoService ?? throw new ArgumentNullException(nameof(customerBankInfoService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public GetBankInfoResponse GetByCustomerId(int customerId)
        {
            var customerBankInfo = _customerBankInfoService.GetByCustomerId(customerId);
            return _mapper.Map<GetBankInfoResponse>(customerBankInfo);
        }

        public IEnumerable<GetBankInfoWithCustomerResponse> GetAll()
        {
            var customersBankInfo = _customerBankInfoService.GetAll();
            return _mapper.Map<IEnumerable<GetBankInfoWithCustomerResponse>>(customersBankInfo);
        }
    }
}
