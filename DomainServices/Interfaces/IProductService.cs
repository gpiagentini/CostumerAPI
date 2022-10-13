using DomainModels;

namespace DomainServices.Interfaces
{
    public interface IProductService
    {
        public Product GetById(int id);
        public bool ProductExists(int id);
    }
}
