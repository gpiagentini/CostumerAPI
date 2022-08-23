using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Interfaces
{
    public interface ICustomerRepository
    {
        public int CreateNew(CustomerBase customer);
        public CustomerBase GetById(int id);
        public List<CustomerBase> GetAll();
        public void Remove(int id);
        public void Update(int id, CustomerBase customer);
    }
}
