using System.Collections.Generic;

namespace DomainModels
{
    public class Portfolio : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalBalance { get; set; }
        public int CustomerId { get; }
        public CustomerBase Customer { get; }
        public ICollection<PortfolioProduct> Products { get; set; }
    }
}
