using DomainModels;
using DomainServices.Exceptions;
using DomainServices.Interfaces;
using EntityFrameworkCore.Repository.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DomainServices
{
    public class CustomerBankInfoService : ServiceBase, ICustomerBankInfoService
    {
        private readonly IRepository<CustomerBankInfo> _customerBankInfoRepository;
        public CustomerBankInfoService(IUnitOfWork<MicroserviceDbContext> unitOfWork, IRepositoryFactory<MicroserviceDbContext> repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
            _customerBankInfoRepository = RepositoryFactory.Repository<CustomerBankInfo>();
        }

        public CustomerBankInfo GetByCustomerId(int customerId)
        {
            var query = _customerBankInfoRepository.SingleResultQuery()
                .AndFilter(e => e.CustomerId.Equals(customerId));
            return _customerBankInfoRepository.FirstOrDefault(query);
        }

        public IEnumerable<CustomerBankInfo> GetAll()
        {
            var query = _customerBankInfoRepository.MultipleResultQuery()
                  .Include(query => query.Include(c => c.Customer));
            return _customerBankInfoRepository.Search(query);
        }

        public void WithdrawValue(CustomerBankInfo customerBankInfo, decimal value)
        {
            if (customerBankInfo.AccountBalance < value) throw new BankInfoDatabaseValidatorException("Saldo insuficiente pára completar a solicitação.");
            customerBankInfo.AccountBalance -= value;
            _customerBankInfoRepository.Update(customerBankInfo);
            UnitOfWork.SaveChanges();
        }

        public void DepositValue(CustomerBankInfo customerBankInfo, decimal value)
        {
            customerBankInfo.AccountBalance += value;
            _customerBankInfoRepository.Update(customerBankInfo);
            UnitOfWork.SaveChanges();
        }
    }
}
