using CostumersAPI.Services.Interfaces;
using CostumersAPI.Costumer;
using CostumersAPI.Validations;
using FluentValidation;

namespace CostumersAPI.Services
{
    public class CostumersService : ICostumerService
    {
        private List<CostumerBase> _inMemoryCostumers = new List<CostumerBase>();

        public void ProcessNewCostumer(CostumerBase costumer)
        {
            _validateIncomingCustomer(costumer);
            _saveNewCostumer(costumer);
        }

        private void _saveNewCostumer(CostumerBase costumer)
        {
            Console.WriteLine("Save new costumer in memory");
            _inMemoryCostumers.Add(costumer);
        }

        private bool _validateIncomingCustomer(CostumerBase costumer)
        {
            var costumerValidator = new NewCustomersValidator();
            try
            {
                costumerValidator.ValidateAndThrow(costumer);
                return true;
            }
            catch (ValidationException e)
            {
                throw e;
            }
        }
    }
}