using AppServices.Mappers.Portfolio.Requests;
using AppServices.Mappers.Portfolio.Responses;

namespace AppServices.Interfaces
{
    public interface IPortfolioAppService
    {
        public int Create(CreateNewPortfolioRequest request);
        public GetPortfolioByIdPortfolioResponse GetByIdPortfolio(int idPortfolio);
    }
}
