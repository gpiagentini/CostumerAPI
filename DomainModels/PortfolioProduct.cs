using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class PortfolioProduct
    {
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
