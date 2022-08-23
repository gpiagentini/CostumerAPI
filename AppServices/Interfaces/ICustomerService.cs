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
        public int ProcessNewCustomer(CustomerBase customer);
        public CustomerBase GetSingleCustomer(int id);
        public List<CustomerBase> GetAllCustomers();
        public void DeleteCustomer(int id);
        public void UpdateCustomer(int id, CustomerBase customer);

    }
}
