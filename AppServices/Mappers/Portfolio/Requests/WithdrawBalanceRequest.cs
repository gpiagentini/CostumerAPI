namespace AppServices.Mappers.Portfolio.Requests
{

    public class WithdrawBalanceRequest
    {
        public int PortfolioId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }

}
