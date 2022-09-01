using System.Collections.Generic;
using System;
using DomainModels;
using AppServices.Interfaces;
using DomainModels.Interfaces;

namespace AppServices
{
    public class CustomersAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersAppService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public int Add(CustomerBase costumer)
        {
            return _customerRepository.Add(costumer);
        }

        public CustomerBase Get(int id)
        {
            return _customerRepository.GetById(id);
        }

        public List<CustomerBase> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public void Delete(int id)
        {
            _customerRepository.Remove(id);
        }

        public void Update(int id, CustomerBase customer)
        {
            _customerRepository.Update(id, customer);
        }
    }
}