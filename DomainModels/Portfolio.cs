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
        public ICollection<PortfolioProduct> Products { get; set; }
    }
}
