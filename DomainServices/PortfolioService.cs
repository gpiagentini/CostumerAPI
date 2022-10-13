using DomainModels;
using DomainServices.Exceptions;
using DomainServices.Interfaces;
using EntityFrameworkCore.Repository.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DomainServices
{
    public class PortfolioService : ServiceBase, IPortfolioService
    {
        private readonly IRepository<Portfolio> _portfolioRepository;

        public PortfolioService(IUnitOfWork<MicroserviceDbContext> unitOfWork, IRepositoryFactory<MicroserviceDbContext> repositoryFactory) : base(unitOfWork, repositoryFactory)
        {
            _portfolioRepository = RepositoryFactory.Repository<Portfolio>();
        }

        public int Create(Portfolio portfolio)
        {
            if (PortfolioExistsByName(portfolio.Name)) throw new PortfolioDatabaseValidationException($"Portfólio \"{portfolio.Name}\" já existe");
            _portfolioRepository.Add(portfolio);
            UnitOfWork.SaveChanges();
            return portfolio.Id;
        }

        public void Update(Portfolio portfolio)
        {
            _portfolioRepository.Update(portfolio);
            UnitOfWork.SaveChanges();
        }

        public void Deposit(Portfolio portfolio, decimal amount)
        {
            portfolio.TotalBalance += amount;
            _portfolioRepository.Update(portfolio);
            UnitOfWork.SaveChanges();
        }

        public Portfolio GetByIdPortfolio(int id)
        {
            var query = _portfolioRepository.SingleResultQuery()
                .AndFilter(portfolio => portfolio.Id.Equals(id))
                .Include(query => query.Include(p => p.Products));
            return _portfolioRepository.FirstOrDefault(query);
        }

        public void Delete(Portfolio portfolio)
        {
            _portfolioRepository.Remove(portfolio);
            UnitOfWork.SaveChanges();
        }

        private bool PortfolioExistsByName(string name)
        {
            return _portfolioRepository.Any(portfolio => portfolio.Name.Equals(name));
        }

        public bool CheckProductExists(Portfolio portfolio, int idProduct)
        {
            return portfolio.Products.Any(product => product.Id.Equals(idProduct));
        }
    }
}
