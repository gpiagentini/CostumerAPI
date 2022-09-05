using DomainModels;
using System.Collections.Generic;

namespace DomainServices.Interfaces
{
    public interface ICustomerService
    {
        int Add(CustomerBase customer);
        CustomerBase GetById(int id);
        List<CustomerBase> GetAll();
        void Remove(int id);
        void Update(CustomerBase customer);
    }
}
