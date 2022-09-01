using AppServices.Mappers.Customer;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface ICustomerAppService
    {
        int Add(CreateCustomerRequest customer);
        GetCustomerResponse Get(int id);
        List<GetCustomerResponse> GetAll();
        void Delete(int id);
        void Update(int id, UpdateCustomerRequest customer);
    }
}
