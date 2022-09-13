using AppServices.Mappers.CustomerBankInfo.Responses;
using DomainModels;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface ICustomerBankInfoAppService
    {
        GetBankInfoResponse GetByCustomerId(int customerId);
        IEnumerable<GetBankInfoWithCustomerResponse> GetAll();
    }
}
