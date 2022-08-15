using CostumersAPI.Costumer;

namespace CostumersAPI.Services.Interfaces
{
    public interface ICostumerService
    {
        void ProcessNewCostumer(CostumerBase costumer);
    }
}
