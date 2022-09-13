using AppServices.Mappers.Customer.Requests;
using AppServices.Mappers.Customer.Responses;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface ICustomerAppService
    {
        int Add(CreateCustomerRequest customer);
        GetCustomerResponse Get(int id);
        IEnumerable<GetCustomerResponse> GetAll();
        void Delete(int id);
        void Update(int id, UpdateCustomerRequest customer);
    }
}
