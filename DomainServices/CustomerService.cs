using DomainModels;
using DomainModels.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DomainServices
{
    public class CustomerService : ICustomerRepository
    {
        public List<CustomerBase> _inMemoryCustomers = new List<CustomerBase>();

        public int CreateNew(CustomerBase customer)
        {
            customer.Id = _inMemoryCustomers.LastOrDefault() != null ? _inMemoryCustomers.LastOrDefault().Id + 1 : 1;
            _inMemoryCustomers.Add(customer);
            return customer.Id;
        }

        public CustomerBase GetById(int id)
        {
            return _inMemoryCustomers.Where(customer => customer.Id == id).FirstOrDefault();
        }

        public List<CustomerBase> GetAll()
        {
            return _inMemoryCustomers;
        }

        public void Remove(int id)
        {
            var customerToRemove = _inMemoryCustomers.Where(customer => customer.Id == id).FirstOrDefault();
            if (customerToRemove == null) throw new ArgumentOutOfRangeException();
            _inMemoryCustomers.Remove(customerToRemove);
        }

        public void Update(int id, CustomerBase updatedCustomer)
        {
            var customerToUpdate = _inMemoryCustomers.FirstOrDefault(customer => customer.Id == id);
            if (customerToUpdate == null) throw new ArgumentOutOfRangeException();
            else
            {
                updatedCustomer.Id = customerToUpdate.Id;
                var index = _inMemoryCustomers.IndexOf(customerToUpdate);
                _inMemoryCustomers[index] = updatedCustomer;
            }
        }
    }
}