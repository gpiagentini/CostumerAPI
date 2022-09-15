using AppServices.Mappers.CustomerBankInfo.Requests;
using AppServices.Mappers.CustomerBankInfo.Responses;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface ICustomerBankInfoAppService
    {
        GetBankInfoResponse GetByCustomerId(int customerId);
        IEnumerable<GetBankInfoWithCustomerResponse> GetAll();
        void UpdateAccountByCustomerId(int customerId, UpdateCustomerBankInfoRequest request);
    }
}
