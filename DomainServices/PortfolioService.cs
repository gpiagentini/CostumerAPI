using DomainModels;
using DomainServices.Exceptions;
using DomainServices.Interfaces;
using EntityFrameworkCore.Repository.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data;

namespace DomainServices
{
    public class PortfolioService : ServiceBase, IPortfolioService
    {
        private readonly IRepository<Portfolio> _portfolioRepository;

        public PortfolioService(IUnitOfWork<MicroserviceDbContext> unitOfWork, IRepositoryFactory<MicroserviceDbContext> repositoryFactory) : base(unitOfWork, repositoryFactory)
        {
            _portfolioRepository = repositoryFactory.Repository<Portfolio>();
        }

        public int Create(Portfolio portfolio)
        {
            if (PortfolioExistsByName(portfolio.Name)) throw new PortfolioDatabaseValidationException($"Portfólio \"{portfolio.Name}\" já existe");
            _portfolioRepository.Add(portfolio);
            UnitOfWork.SaveChanges();
            return portfolio.Id;
        }

        public Portfolio GetByIdPortfolio(int id)
        {
            var query = _portfolioRepository.SingleResultQuery()
                .AndFilter(portfolio => portfolio.Id.Equals(id));
            return _portfolioRepository.FirstOrDefault(query);
        }

        private bool PortfolioExistsByName(string name)
        {
            return _portfolioRepository.Any(portfolio => portfolio.Name.Equals(name));
        }
    }
}
