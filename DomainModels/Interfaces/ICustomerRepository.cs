using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Interfaces
{
    public interface ICustomerRepository
    {
        int CreateNew(CustomerBase customer);
        CustomerBase GetById(int id);
        List<CustomerBase> GetAll();
        void Remove(int id);
        void Update(int id, CustomerBase customer);
    }
}
