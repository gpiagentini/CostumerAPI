using System;

namespace AppServices.Mappers.Portfolio.Requests
{
    public class InvestmentRequest
    {
        public int PortfolioId { get; set; }
        public int ProductId { get; set; }
        public int Quotes { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime LiquidatedAt { get; set; }
    }
}
