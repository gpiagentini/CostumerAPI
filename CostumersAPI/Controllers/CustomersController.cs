using AppServices.Interfaces;
using AppServices.Mappers.Customer.Requests;
using DomainModels;
using DomainServices.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

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

        public IActionResult Post(CreateCustomerRequest customer)
        {
            try
            {
                var idNewCustomer = _customerService.Add(customer);
                return CreatedAtRoute(nameof(Get), new { id = idNewCustomer }, customer);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (CustomerDatabaseValidatorException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while trying to save new customer.");
                return Problem("Não foi possível completar a solicitação");
            }
        }

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(CustomerBase), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                var customer = _customerService.Get(id);
                return customer == null ? NotFound($"Nenhum cliente encontrado com o ID: {id}") : Ok(customer);
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
                return customers.Any() ? Ok(customers) : NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while trying to fetch all customers.");
                return Problem($"Não foi possível completar solicitação.");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                _customerService.Delete(id);
                return NoContent();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error ocurred while trying to delete customer {id}", id);
                return Problem("Não foi possível completar sua solicitação.");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, UpdateCustomerRequest customer)
        {
            try
            {
                _customerService.Update(id, customer);
                return Ok("Cliente atualizado com sucesso");
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (CustomerDatabaseValidatorException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error ocurred while trying to update customer {id}", id);
                return Problem("Não foi possível completar a solicitação");
            }
        }
    }
}