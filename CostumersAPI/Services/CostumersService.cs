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
        private List<CostumerBase> _inMemoryCostumers = new List<CostumerBase>();

        public int ProcessNewCustomer(CostumerBase costumer)
        {
            return _saveNewCostumer(costumer);
        }

        public CostumerBase GetCustomer(int id)
        {
            return _inMemoryCostumers.ElementAt(id);
        }

        public List<CostumerBase> GetAllCustomers()
        {
            return _inMemoryCostumers;
        }

        public void DeleteCustomer(int id)
        {
            _inMemoryCostumers.RemoveAt(id);
        }

        public void PutCustomer(int id, CostumerBase customer)
        {
            _inMemoryCostumers[id] = customer;
        }

        private int _saveNewCostumer(CostumerBase costumer)
        {
            _inMemoryCostumers.Add(costumer);
            return _inMemoryCostumers.Count - 1;
        }

    }
}