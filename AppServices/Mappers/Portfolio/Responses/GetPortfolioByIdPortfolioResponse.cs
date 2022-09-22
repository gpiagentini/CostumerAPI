using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Mappers.Portfolio.Responses
{
    public class GetPortfolioByIdPortfolioResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalBalance { get; set; }
    }
}
