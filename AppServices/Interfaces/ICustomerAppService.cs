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
        int Add(CustomerBase customer);
        CustomerBase Get(int id);
        List<CustomerBase> GetAll();
        void Delete(int id);
        void Update(int id, CustomerBase customer);
    }
}
