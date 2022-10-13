using AppServices.Mappers.Portfolio.Requests;
using AppServices.Mappers.Portfolio.Responses;
using DomainModels;

namespace AppServices.Interfaces
{
    public interface IPortfolioAppService
    {
        public int Create(CreateNewPortfolioRequest request);
        public GetPortfolioByIdPortfolioResponse GetByIdPortfolio(int idPortfolio);
        public void ProcessDepositRequest(DepositRequest request);
        public void ProcessWithdrawRequest(WithdrawBalanceRequest withdrawRequest);
        public void ProcessInvestmentRequest(InvestmentRequest request, OrderDirection direction);
        public void Delete(int idPortfolio);
    }
}
