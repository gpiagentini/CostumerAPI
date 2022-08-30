using CostumersAPI.Costumer;
using System.Collections.Generic;

namespace CostumersAPI.Services.Interfaces
{
    public interface ICostumerService
    {
        int Add(CostumerBase costumer);
        CostumerBase Get(int id);
        List<CostumerBase> GetAll();
        void Delete(int id);
        void Put(int id, CostumerBase customer);
    }
}
