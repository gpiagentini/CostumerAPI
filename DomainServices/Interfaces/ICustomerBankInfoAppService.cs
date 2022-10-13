using DomainModels;
using System.Collections.Generic;

namespace DomainServices.Interfaces
{
    public interface ICustomerBankInfoService
    {
        CustomerBankInfo GetByCustomerId(int customerId);
        IEnumerable<CustomerBankInfo> GetAll();
        void WithdrawValue(CustomerBankInfo customerBankInfo, decimal value);
        void DepositValue(CustomerBankInfo customerBankInfo, decimal value);
    }
}
