using CostumersAPI.Costumer;

namespace CostumersAPI.Services.Interfaces
{
    public interface ICostumerService
    {
        int ProcessNewCustomer(CostumerBase costumer);
        CostumerBase GetCustomer(int id);
        List<CostumerBase> GetAllCustomers();
        void DeleteCustomer(int id);
        void PutCustomer(int id, CostumerBase customer);
    }
}
