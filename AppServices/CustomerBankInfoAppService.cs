using AppServices.Interfaces;
using AppServices.Mappers.CustomerBankInfo.Requests;
using AppServices.Mappers.CustomerBankInfo.Responses;
using AutoMapper;
using DomainServices.Exceptions;
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

        public void UpdateAccountByCustomerId(int customerId, UpdateCustomerBankInfoRequest request)
        {
            var customerBankInfo = _customerBankInfoService.GetByCustomerId(customerId);
            if (customerBankInfo == null) throw new BankInfoDatabaseValidatorException("Nenhum dado de conta corrente encontrado para o cliente requisitado");
            if (request.RequestType.Equals(AccountRequestType.Deposit))
                _customerBankInfoService.DepositValue(customerBankInfo, request.Value);
            else if (request.RequestType.Equals(AccountRequestType.Withdraw))
                _customerBankInfoService.WithdrawValue(customerBankInfo, request.Value);

        }
    }
}
