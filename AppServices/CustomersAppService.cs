using System.Collections.Generic;
using System;
using DomainModels;
using DomainServices;
using AppServices.Interfaces;
using AppServices.Mappers.Customer;
using AutoMapper;
using DomainServices.Interfaces;

namespace AppServices
{
    public class CustomersAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerRepository;

        public CustomersAppService(ICustomerService customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public int Add(CreateCustomerRequest createCustomerRequest)
        {
            var customerBase = _mapper.Map<CustomerBase>(createCustomerRequest);
            return _customerRepository.CreateNew(customerBase);
        }

        public GetCustomerResponse Get(int id)
        {
            var customerBase = _customerRepository.GetById(id);
            return _mapper.Map<GetCustomerResponse>(customerBase);
        }

        public List<GetCustomerResponse> GetAll()
        {
            var customerBaseList = _customerRepository.GetAll();
            return _mapper.Map<List<GetCustomerResponse>>(customerBaseList);
        }

        public void Delete(int id)
        {
            _customerRepository.Remove(id);
        }

        public void Update(int id, UpdateCustomerRequest updateCustomerRequest)
        {
            var customerBase = _mapper.Map<CustomerBase>(updateCustomerRequest);
            _customerRepository.Update(id, customerBase);
        }
    }
}