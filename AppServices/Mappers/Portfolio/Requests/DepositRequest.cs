using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Mappers.Portfolio.Requests
{
    public class DepositRequest
    {
        public int PortfolioId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }
}
