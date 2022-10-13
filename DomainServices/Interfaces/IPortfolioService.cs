using DomainModels;

namespace DomainServices.Interfaces
{
    public interface IPortfolioService
    {
        public int Create(Portfolio portfolio);
        public void Update(Portfolio portfolio);
        public Portfolio GetByIdPortfolio(int id);
        public void Delete(Portfolio portfolio);
        public void Deposit(Portfolio portfolio, decimal amount);
        public bool CheckProductExists(Portfolio portfolio, int idProduct);
    }
}
