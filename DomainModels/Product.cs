using System;
using System.Collections.Generic;

namespace DomainModels
{
    public class Product : EntityBase
    {
        public string Symbol { get; set; }
        public DateTime IssuanceAt { get; set; }
        public DateTime ExpirationAt { get; set; }
        public int DaysToExpire { get; set; }
        public ProductType Type { get; set; }

        public ICollection<PortfolioProduct> Portfolios { get; set; }
    }

    public enum ProductType
    {
        FixedIncome = 1, // Renda fixa
        Trade = 2, // Ações
        Funds = 3, // Fundos de investimento
        Fii = 4, // Fundos imobiliários
        Crypto = 5 // Crypto moedas
    }
}
