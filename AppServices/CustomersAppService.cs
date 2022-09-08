using AppServices.Interfaces;
using AppServices.Mappers.Customer;
using AutoMapper;
using DomainModels;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;

namespace AppServices
{
    public class CustomersAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomersAppService(ICustomerService customerRepository, IMapper mapper)
        {
            _customerService = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public int Add(CreateCustomerRequest createCustomerRequest)
        {
            var customerBase = _mapper.Map<CustomerBase>(createCustomerRequest);
            return _customerService.Add(customerBase);
        }

        public GetCustomerResponse Get(int id)
        {
            var customerBase = _customerService.GetById(id);
            return _mapper.Map<GetCustomerResponse>(customerBase);
        }

        public IEnumerable<GetCustomerResponse> GetAll()
        {
            var customerBaseList = _customerService.GetAll();
            return _mapper.Map<IEnumerable<GetCustomerResponse>>(customerBaseList);
        }

        public void Delete(int id)
        {
            _customerService.Remove(id);
        }

        public void Update(int id, UpdateCustomerRequest updateCustomerRequest)
        {
            var customerBase = _mapper.Map<CustomerBase>(updateCustomerRequest);
            customerBase.Id = id;
            _customerService.Update(customerBase);
        }
    }
}