using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Mappers.Product.Responses
{
    public class GetProductResponse
    {
        public string Symbol { get; set; }
        public string ExpirationAt { get; set; }
        public string ProductType { get; set; }
    }
}
