using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Interfaces
{
    public interface ICustomerService
    {
        int ProcessNewCustomer(CustomerBase customer);
        CustomerBase GetSingleCustomer(int id);
        List<CustomerBase> GetAllCustomers();
        void DeleteCustomer(int id);
        void UpdateCustomer(int id, CustomerBase customer);
    }
}
