using System.Collections.Generic;

namespace DomainModels
{
    public class Portfolio : EntityBase
    {
        public Portfolio()
        {
            TotalBalance = 0;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalBalance { get; set; }
        public int CustomerId { get; set; }
        public CustomerBase Customer { get; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }

        public void Debit(decimal value)
        {
            TotalBalance -= value;
        }

        public void Deposit(decimal value)
        {
            TotalBalance += value;
        }
    }
}
