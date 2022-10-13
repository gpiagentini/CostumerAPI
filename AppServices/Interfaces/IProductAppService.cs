using AppServices.Mappers.Product.Requests;
using AppServices.Mappers.Product.Responses;

namespace AppServices.Interfaces
{
    public interface IProductAppService
    {
        GetProductResponse GetByIdProduct(int id);
        int CreateNewProduct(NewProductRequest request);
    }
}
