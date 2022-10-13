using DomainModels;

namespace DomainServices.Interfaces
{
    public interface IProductService
    {
        Product GetById(int id);
        int Create(Product product);
        bool ProductExists(int id);
    }
}
