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

        public int Add(CostumerBase costumer)
        {
            _inMemoryCostumers.Add(costumer);
            return _inMemoryCostumers.Count - 1;
        }

        public CostumerBase Get(int id)
        {
            return _inMemoryCostumers.ElementAt(id);
        }

        public List<CostumerBase> GetAll()
        {
            return _inMemoryCostumers;
        }

        public void Delete(int id)
        {
            _inMemoryCostumers.RemoveAt(id);
        }

        public void Update(int id, CostumerBase customer)
        {
            _inMemoryCostumers[id] = customer;
        }

    }
}