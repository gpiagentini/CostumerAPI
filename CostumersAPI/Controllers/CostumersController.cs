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
        public IActionResult Post(CostumerBase costumer)
        {
            try
            {
                var idNewCustomer = _costumerService.Add(costumer);      
                return CreatedAtAction(nameof(Get), new { id = idNewCustomer }, costumer);
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
        public IActionResult Get(int id)
        {
            try
            {
                var costumer = _costumerService.Get(id);
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
        public IActionResult GetAll()
        {
            try
            {
                var costumers = _costumerService.GetAll();
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
        public IActionResult Delete(int id)
        {
            try
            {
                _costumerService.Delete(id);
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
        public IActionResult Put(int id, CostumerBase customer)
        {
            try
            {
                _costumerService.Put(id, customer);
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