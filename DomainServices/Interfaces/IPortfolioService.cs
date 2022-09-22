using DomainModels;

namespace DomainServices.Interfaces
{
    public interface IPortfolioService
    {
        public int Create(Portfolio portfolio);
        public Portfolio GetByIdPortfolio(int id);
    }
}
