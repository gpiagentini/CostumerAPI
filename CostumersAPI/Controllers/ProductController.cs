using System;
using AppServices;
using AppServices.Interfaces;
using AppServices.Mappers.Product.Requests;
using AppServices.Mappers.Product.Responses;
using DomainServices.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        private ILogger<ProductController> _logger;

        public ProductController(IProductAppService productAppService, ILogger<ProductController> logger)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{id}", Name = "GetByIdProduct")]
        [ProducesResponseType(typeof(GetProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult GetByIdProduct(int id)
        {
            try
            {
                var response = _productAppService.GetByIdProduct(id);
                return Ok(response);
            }
            catch (ProductDatabaseValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception ocurred while trying to get product");
                return Problem("Não foi possível completar a solicitação");
            }

        }

        [HttpPost]
        public IActionResult Create(NewProductRequest newProductRequest)
        {
            var idProduct = _productAppService.CreateNewProduct(newProductRequest);
            return CreatedAtRoute(nameof(GetByIdProduct), new { id = idProduct}, newProductRequest);
        }
    }
}
