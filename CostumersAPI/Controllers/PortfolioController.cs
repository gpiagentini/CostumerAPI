using AppServices;
using AppServices.Interfaces;
using AppServices.Mappers.Portfolio.Requests;
using DomainModels;
using DomainServices.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CustomersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioAppService _potfolioAppService;
        private ILogger<PortfolioController> _logger;

        public PortfolioController(IPortfolioAppService potfolioAppService, ILogger<PortfolioController> logger)
        {
            _potfolioAppService = potfolioAppService ?? throw new ArgumentNullException(nameof(potfolioAppService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Portfolio), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Create(CreateNewPortfolioRequest request)
        {
            try
            {
                int idNewPortfolio = _potfolioAppService.Create(request);
                return CreatedAtRoute(nameof(GetByIdPortfolio), new { idPortfolio = idNewPortfolio }, request);
            }
            catch (PortfolioDatabaseValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while trying to create a new Portfolio");
                return Problem("Não foi possível completar a solicitação");
            }
        }

        [HttpGet("{idPortfolio}", Name = "GetByIdPortfolio")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetByIdPortfolio(int idPortfolio)
        {
            try
            {
                var portfolioResponse = _potfolioAppService.GetByIdPortfolio(idPortfolio);
                return portfolioResponse != null ? Ok(portfolioResponse) : NotFound($"Nenhum recurso encontrado para o id {idPortfolio}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception ocurred while trying to fetch porfolio {id}", idPortfolio);
                return Problem("Não foi possível completar a solicitação");
            }
        }


    }
}
