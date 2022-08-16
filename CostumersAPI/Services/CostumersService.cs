using CostumersAPI.Services.Interfaces;
using CostumersAPI.Costumer;
using CostumersAPI.Validations;
using FluentValidation;
using System.Reflection;

namespace CostumersAPI.Services
{
    public class CostumersService : ICostumerService
    {
        private List<CostumerBase> _inMemoryCostumers = new List<CostumerBase>();

        public int ProcessNewCustomer(CostumerBase costumer)
        {
            _validateIncomingCustomer(costumer);
            return _saveNewCostumer(costumer);
        }

        public CostumerBase GetCustomer(int id)
        {
            try
            {
                return _inMemoryCostumers.ElementAt(id);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
        }

        public List<CostumerBase> GetAllCustomers()
        {
            return _inMemoryCostumers;
        }

        public void DeleteCustomer(int id)
        {
            try
            {
                _inMemoryCostumers.RemoveAt(id);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
        }

        public void PutCustomer(int id, CostumerBase customer)
        {
            _validatePutCustomer(customer);
            try
            {
                _inMemoryCostumers[id] = customer;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
        }

        private int _saveNewCostumer(CostumerBase costumer)
        {
            _inMemoryCostumers.Add(costumer);
            return _inMemoryCostumers.Count - 1;
        }

        private void _validateIncomingCustomer(CostumerBase costumer)
        {
            var costumerValidator = new NewCustomersValidator();
            try
            {
                costumerValidator.ValidateAndThrow(costumer);
            }
            catch (ValidationException e)
            {
                throw e;
            }
        }

        private void _validatePutCustomer(CostumerBase costumer)
        {
            var costumerValidator = new PutCustomerValidation();
            try
            {
                costumerValidator.ValidateAndThrow(costumer);
            }
            catch (ValidationException e)
            {
                throw e;
            }
        }
    }
}