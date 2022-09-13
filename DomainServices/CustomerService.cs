using DomainModels;
using DomainServices.Exceptions;
using DomainServices.Interfaces;
using EntityFrameworkCore.Repository.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices
{
    public class CustomerService : ServiceBase, ICustomerService
    {
        private readonly IRepository<CustomerBase> _customerRepository;
        public CustomerService(IUnitOfWork<MicroserviceDbContext> unitOfWork, IRepositoryFactory<MicroserviceDbContext> repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
            _customerRepository = RepositoryFactory.Repository<CustomerBase>();
        }

        public int Add(CustomerBase customer)
        {
            TryValidateCustomer(customer);
            customer.BankInfo = new CustomerBankInfo();
            _customerRepository.Add(customer);
            UnitOfWork.SaveChanges();
            return customer.Id;
        }

        public CustomerBase GetById(int id)
        {
            var query = _customerRepository.SingleResultQuery()
                .AndFilter(customer => customer.Id.Equals(id))
                .Include(query => query.Include(c => c.BankInfo));
            return _customerRepository.FirstOrDefault(query);
        }

        public IEnumerable<CustomerBase> GetAll()
        {
            var query = _customerRepository.MultipleResultQuery()
                .Include(query => query.Include(c => c.BankInfo));
            return _customerRepository.Search(query);
        }

        public void Remove(int id)
        {
            if (!CustomerExists(id)) throw new ArgumentException($"Nenhum recurso encontrado com o ID: {id}");
            var customerToBeRemoved = GetById(id);
            _customerRepository.Remove(customerToBeRemoved);
            UnitOfWork.SaveChanges(true);
        }

        public void Update(CustomerBase customerToUpdate)
        {
            if (!CustomerExists(customerToUpdate.Id)) throw new ArgumentException($"Nenhum recurso encontrado com o ID: {customerToUpdate.Id}");
            TryValidateCustomer(customerToUpdate);
            _customerRepository.Update(customerToUpdate);
            UnitOfWork.SaveChanges();
        }

        private bool CustomerExists(int id)
        {
            return _customerRepository.Any(customer => customer.Id == id);
        }

        private bool IsCpfUnique(CustomerBase customerToBeValidated)
        {
            bool isCpfUnique = !_customerRepository.Any(customer => customer.Cpf.Equals(customerToBeValidated.Cpf) && !customer.Id.Equals(customerToBeValidated.Id));
            return isCpfUnique;
        }

        private bool IsEmailUnique(CustomerBase customerToBeValidated)
        {
            bool isEmailUnique = !_customerRepository.Any(customer => customer.Email.Equals(customerToBeValidated.Email) && !customer.Id.Equals(customerToBeValidated.Id));
            return isEmailUnique;
        }

        /// <exception cref="CustomerDatabaseValidatorException">
        /// This excetion is thrown when some customer field cannot be validated in the Database
        /// </exception>
        private bool TryValidateCustomer(CustomerBase customer)
        {
            if (!IsCpfUnique(customer)) throw new CustomerDatabaseValidatorException($"Cpf já cadastrado.");
            if (!IsEmailUnique(customer)) throw new CustomerDatabaseValidatorException($"Email já cadastrado.");
            return true;
        }
    }
}