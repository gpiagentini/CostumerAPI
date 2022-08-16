using Microsoft.AspNetCore.Mvc;
using CostumersAPI.Costumer;
using CostumersAPI.Services.Interfaces;
using FluentValidation;

namespace CostumersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CostumersController : ControllerBase
    {
        private readonly ICostumerService _costumerService;

        public CostumersController(ICostumerService costumerService)
        {
            if (costumerService != null)
                _costumerService = costumerService;
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
                int idNewCustomer = _costumerService.ProcessNewCustomer(costumer);
                return CreatedAtAction(nameof(GetCostumer), new { id = idNewCustomer }, costumer);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception while saving new costumer: {e}");
                return Problem("Não foi possível completar a solicitação");
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
                CostumerBase costumer = _costumerService.GetCustomer(id);
                return Ok(costumer);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return NotFound($"Nenhum cliente encontrado com o ID: {id}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception while saving new costumer: {e.Message}");
                return Problem($"Não foi possível completar solicitação");
            }
        }

        [HttpGet(Name = "customers")]
        [ProducesResponseType(typeof(CostumerBase), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllCostumers()
        {
            try
            {
                List<CostumerBase> costumers = _costumerService.GetAllCustomers();
                if (costumers.Count == 0)
                    return NotFound("Nenhum Cliente encontrado!");
                else
                    return Ok(costumers);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception while saving new costumer: {e.Message}");
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
                return Ok("Cliente removido com sucesso");
            }
            catch (ArgumentOutOfRangeException e)
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
                return Ok("Cliente atualizado com sucesso");
            }
            catch (ArgumentOutOfRangeException e)
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