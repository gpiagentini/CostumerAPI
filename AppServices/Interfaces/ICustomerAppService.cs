using AppServices.Mappers.Customer;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
