using System;
using Microsoft.AspNetCore.Mvc;
using CostumersAPI.Costumer;
using CostumersAPI.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace CostumersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CostumersController : ControllerBase
    {
        private readonly ICostumerService _costumerService;
        private readonly ILogger<CostumersController> _logger;

        public CostumersController(ICostumerService costumerService, ILogger<CostumersController> logger)
        {
            _costumerService = costumerService ?? throw new ArgumentNullException(nameof(costumerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult PostNewCostumer(CostumerBase costumer)
        {
            try
            {
                var idNewCustomer = _costumerService.ProcessNewCustomer(costumer);      
                return CreatedAtAction(nameof(GetCostumer), new { id = idNewCustomer }, costumer);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while trying to save new costumer.");
                return Problem("Não foi possível completar a solicitação.");
            }
        }

        [HttpGet("{id}", Name = "customer")]
        [ProducesResponseType(typeof(CostumerBase), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetCostumer(int id)
        {
            try
            {
                var costumer = _costumerService.GetCustomer(id);
                return Ok(costumer);
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Nenhum cliente encontrado com o ID: {id}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while trying to fetch custumer {id}.", id);
                return Problem($"Não foi possível completar solicitação");
            }
        }

        [HttpGet(Name = "customers")]
        [ProducesResponseType(typeof(CostumerBase), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllCostumers()
        {
            try
            {
                var costumers = _costumerService.GetAllCustomers();
                return costumers.Count == 0 ? NoContent() : Ok(costumers); 
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while trying to fetch all customers.");
                return Problem($"Não foi possível completar solicitação");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                _costumerService.DeleteCustomer(id);
                _logger.LogWarning("Customer deleted for Id: {id}", id);
                return NoContent();
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Nenhum recurso encontrado com o ID: {id}");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult PutCustomer(int id, CostumerBase customer)
        {
            try
            {
                _costumerService.PutCustomer(id, customer);
                _logger.LogWarning("Customer updated for Id: {id}", id);
                return Ok("Cliente atualizado com sucesso");
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Não foi possível atualizar o cliente de ID: {id}");
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}