using DomainModels;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices
{
    public class CustomerService : ICustomerService
    {
        private readonly List<CustomerBase> _inMemoryCustomers = new();

        public int Add(CustomerBase customer)
        {
            customer.Id = _inMemoryCustomers.Any() ? _inMemoryCustomers.LastOrDefault().Id + 1 : 1;
            _inMemoryCustomers.Add(customer);
            return customer.Id;
        }

        public CustomerBase GetById(int id)
        {
            return _inMemoryCustomers.FirstOrDefault(customer => customer.Id == id);
        }

        public List<CustomerBase> GetAll()
        {
            return _inMemoryCustomers;
        }

        public void Remove(int id)
        {
            var customerToRemove = _inMemoryCustomers.FirstOrDefault(customer => customer.Id == id);
            if (customerToRemove == null) throw new ArgumentException();
            _inMemoryCustomers.Remove(customerToRemove);
        }

        public void Update(CustomerBase customerToUpdate)
        {
            var index = _inMemoryCustomers.FindIndex(customer => customer.Id == customerToUpdate.Id);
            _inMemoryCustomers[index] = customerToUpdate;
        }
    }
}