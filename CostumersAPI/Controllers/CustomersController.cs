using System;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using DomainModels;
using AppServices.Interfaces;

namespace CustomersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerAppService _customerService;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(
            ICustomerAppService customerService,
            ILogger<CustomersController> logger)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Post(CustomerBase customer)
        {
            try
            {
                var idNewCustomer = _customerService.Add(customer);
                return CreatedAtAction(nameof(Get), new { id = idNewCustomer }, customer);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while trying to save new customer.");
                return Problem("Não foi possível completar a solicitação");
            }
        }

        [HttpGet("{id}", Name = "customer")]
        [ProducesResponseType(typeof(CustomerBase), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                var customer = _customerService.Get(id);
                if (customer == null)
                    return NotFound($"Nenhum cliente encontrado com o ID: {id}");
                return Ok(customer);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while trying to fetch customer {id}.", id);
                return Problem("Não foi possível completar solicitação.");
            }
        }

        [HttpGet(Name = "customers")]
        [ProducesResponseType(typeof(CustomerBase), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var customers = _customerService.GetAll();
                return customers.Count == 0 ? NoContent() : Ok(customers);
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
                _customerService.Delete(id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound($"Nenhum recurso encontrado com o ID: {id}");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, CustomerBase customer)
        {
            try
            {
                _customerService.Update(id, customer);
                return Ok("Cliente atualizado com sucesso");
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Nenhum recurso encontrado com o ID: {id}");
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}