using CostumersAPI.Services.Interfaces;
using CostumersAPI.Costumer;
using FluentValidation;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CostumersAPI.Services
{
    public class CostumersService : ICostumerService
    {
        private readonly IValidator<CostumerBase> _validator;
        public CostumersService(IValidator<CostumerBase> validator)
        {
            if (validator != null)
                _validator = validator;
        }

        private List<CostumerBase> _inMemoryCostumers = new List<CostumerBase>();

        public int ProcessNewCustomer(CostumerBase costumer)
        {
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

    }
}