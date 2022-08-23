using System.Collections.Generic;
using System;
using DomainModels;
using AppServices.Interfaces;
using DomainModels.Interfaces;

namespace AppServices
{
    public class CustomersAppService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersAppService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(CustomersAppService));
        }

        public int ProcessNewCustomer(CustomerBase costumer)
        {
            return _customerRepository.CreateNew(costumer);
        }

        public CustomerBase GetSingleCustomer(int id)
        {
            return _customerRepository.GetById(id);
        }

        public List<CustomerBase> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.Remove(id);
        }

        public void UpdateCustomer(int id, CustomerBase customer)
        {
            _customerRepository.Update(id, customer);
        }
    }
}