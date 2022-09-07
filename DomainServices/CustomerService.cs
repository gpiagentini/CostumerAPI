using DomainModels;
using DomainServices.Exceptions;
using DomainServices.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices
{
    public class CustomerService : ICustomerService
    {
        private readonly MicroserviceDbContext _microserviceDbContext;

        public CustomerService(MicroserviceDbContext microserviceDbContext)
        {
            _microserviceDbContext = microserviceDbContext ?? throw new ArgumentNullException(nameof(microserviceDbContext));
        }

        public int Add(CustomerBase customer)
        {
            TryValidateCustomer(customer);
            _microserviceDbContext.CustomerBase.Add(customer);
            _microserviceDbContext.SaveChanges();
            return customer.Id;
        }

        public CustomerBase GetById(int id)
        {
            CustomerBase customer = _microserviceDbContext.CustomerBase.Find(id);
            return customer;
        }

        public List<CustomerBase> GetAll()
        {
            return _microserviceDbContext.CustomerBase.ToList();
        }

        public void Remove(int id)
        {
            if (!CustomerExists(id)) throw new ArgumentException();
            var customerToBeRemoved = GetById(id);
            _microserviceDbContext.Remove(customerToBeRemoved);
            _microserviceDbContext.SaveChanges(true);
        }

        public void Update(CustomerBase customerToUpdate)
        {
            if (!CustomerExists(customerToUpdate.Id)) throw new ArgumentException();
            TryValidateCustomer(customerToUpdate);
            _microserviceDbContext.CustomerBase.Update(customerToUpdate);
            _microserviceDbContext.SaveChanges();
        }

        private bool CustomerExists(int id)
        {
            return _microserviceDbContext.CustomerBase.Any(customer => customer.Id == id);
        }

        private bool IsCpfUnique(CustomerBase customerToBeValidated)
        {
            bool isCprfUnique = !_microserviceDbContext.CustomerBase.Any(customer => customer.Cpf.Equals(customerToBeValidated.Cpf) && !customer.Id.Equals(customerToBeValidated.Id));
            if (!isCprfUnique) throw new CustomerDatabaseValidatorException($"Cpf já cadastrado.");
            return isCprfUnique;
        }

        private bool IsEmailUnique(CustomerBase customerToBeValidated)
        {
            bool isEmailUnique = !_microserviceDbContext.CustomerBase.Any(customer => customer.Email.Equals(customerToBeValidated.Email) && !customer.Id.Equals(customerToBeValidated.Id));
            if (!isEmailUnique) throw new CustomerDatabaseValidatorException($"Email {customerToBeValidated.Email} já cadastrado.");
            return isEmailUnique;
        }

        /// <exception cref="CustomerDatabaseValidatorException">
        /// This excetion is thrown when some customer field cannot be validated in the Database
        /// </exception>
        private bool TryValidateCustomer(CustomerBase customer)
        {
            try
            {
                return IsCpfUnique(customer) && IsEmailUnique(customer);
            }
            catch (CustomerDatabaseValidatorException)
            {
                throw;
            }

        }
    }
}