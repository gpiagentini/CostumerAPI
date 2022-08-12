using CostumersAPI.Costumer;

namespace CostumersAPI.Services
{
    public interface ICostumerService
    {
        void SaveNewCostumer(CostumerBase costumer);
    }

    public class CostumersService : ICostumerService
    {
        private List<CostumerBase> _inMemoryCostumers = new List<CostumerBase>();

        public void SaveNewCostumer(CostumerBase costumer)
        {
            Console.WriteLine("Save new costumer in memory");
            _inMemoryCostumers.Add(costumer);
        }
    }
}