using AppServices.Interfaces;
using AppServices.Mappers.Product.Requests;
using AppServices.Mappers.Product.Responses;
using AutoMapper;
using DomainServices.Exceptions;
using DomainServices.Interfaces;
using DomainModels;
using System;

namespace AppServices
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductAppService(IProductService productService, IMapper mapper)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public GetProductResponse GetByIdProduct(int id)
        {
            var product = _productService.GetById(id);
            if (product == null) throw new ProductDatabaseValidationException($"Produto com id {id} não encontrado");
            return _mapper.Map<GetProductResponse>(product);
        }

        public int CreateNewProduct(NewProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            return _productService.Create(product);
        }
    }
}
