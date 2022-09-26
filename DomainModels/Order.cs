using System;

namespace DomainModels
{
    public class Order : EntityBase
    {
        public int Quotes { get; set; } //Quantidade Cotas
        public decimal UnitPrice { get; set; }
        public decimal NetValue { get; set; } //Valor Líquido
        public DateTime LiquidatedAt { get; set; }
        public OrderDirection Direction { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; }
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; }
    }

    public enum OrderDirection
    {
        Buy = 1,
        Sell = 2
    }
}
