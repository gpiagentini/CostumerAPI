using DomainModels;
using DomainServices.Interfaces;
using EntityFrameworkCore.QueryBuilder;
using EntityFrameworkCore.Repository.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data;

namespace DomainServices
{
    public class ProductService : ServiceBase, IProductService
    {

        private readonly IRepository<Product> _productRepository;
        public ProductService(IUnitOfWork<MicroserviceDbContext> unitOfWork, IRepositoryFactory<MicroserviceDbContext> repositoryFactory) : base(unitOfWork, repositoryFactory)
        {
            _productRepository = RepositoryFactory.Repository<Product>();
        }

        public Product GetById(int id)
        {
            var query = _productRepository.SingleResultQuery()
                .AndFilter(x => x.Id.Equals(id));
            return _productRepository.SingleOrDefault(query);
        }

        public bool ProductExists(int id)
        {
            return _productRepository.Any(x => x.Id.Equals(id));
        }
    }
}
