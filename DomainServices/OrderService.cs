using DomainModels;
using DomainServices.Interfaces;
using EntityFrameworkCore.Repository.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data;

namespace DomainServices
{
    public class OrderService : ServiceBase, IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        public OrderService(IUnitOfWork<MicroserviceDbContext> unitOfWork, IRepositoryFactory<MicroserviceDbContext> repositoryFactory) : base(unitOfWork, repositoryFactory)
        {
            _orderRepository = RepositoryFactory.Repository<Order>();
        }
        public void Add(Order order)
        {
            _orderRepository.Add(order);
            UnitOfWork.SaveChanges();
        }

        public decimal GetSpecificProductPosition(int productId, int portfolioId)
        {
            var buy = _orderRepository.Sum(x => x.Direction.Equals(OrderDirection.Buy) ? x.Quotes : 0);
            var sell = _orderRepository.Sum(x => x.Direction.Equals(OrderDirection.Sell) ? x.Quotes : 0);
            return buy - sell;
        }
    }
}
