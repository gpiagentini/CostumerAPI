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
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(
            ICustomerService customerService,
            ILogger<CustomersController> logger)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(CustomersController));
            _logger = logger ?? throw new ArgumentNullException(nameof(CustomersController));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult PostNewCustomer(CustomerBase customer)
        {
            try
            {
                var idNewCustomer = _customerService.ProcessNewCustomer(customer);
                return CreatedAtAction(nameof(GetCustomer), new { id = idNewCustomer }, customer);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception while saving new customer: {e.Message}");
                return Problem("Não foi possível completar a solicitação");
            }
        }

        [HttpGet("{id}", Name = "customer")]
        [ProducesResponseType(typeof(CustomerBase), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetCustomer(int id)
        {
            try
            {
                var customer = _customerService.GetSingleCustomer(id);
                if(customer == null)
                    return NotFound($"Nenhum cliente encontrado com o ID: {id}");
                return Ok(customer);
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception while fetching custumer {id}: {e.Message}");
                return Problem($"Não foi possível completar solicitação");
            }
        }

        [HttpGet(Name = "customers")]
        [ProducesResponseType(typeof(CustomerBase), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _customerService.GetAllCustomers();
                if (customers.Count == 0)
                    return NotFound("Nenhum Cliente encontrado!");
                else
                    return Ok(customers);
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception while fetching customers: {e.Message}");
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
                _customerService.DeleteCustomer(id);
                _logger.LogWarning($"Cliente {id} removido");
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
        public IActionResult PutCustomer(int id, CustomerBase customer)
        {
            try
            {
                _customerService.UpdateCustomer(id, customer);
                _logger.LogWarning($"Cliente {id} atualizado.");
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