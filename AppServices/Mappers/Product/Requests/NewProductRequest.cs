using DomainModels;
using System;

namespace AppServices.Mappers.Product.Requests
{
    public class NewProductRequest
    {
        public string Symbol{ get; set; }
        public DateTime IssuanceAt { get; set; }
        public DateTime ExpirationAt { get; set; }
        public ProductType Type { get; set; }
    }
}
