using DomainModels;

namespace DomainServices.Interfaces
{
    public interface IOrderService
    {
        public void Add(Order order);
        public decimal GetSpecificProductPosition(int productId, int portfolioId);
    }
}
