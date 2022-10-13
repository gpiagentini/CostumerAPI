using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Mappers.Portfolio.Requests
{
    public class CreateNewPortfolioRequest
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
