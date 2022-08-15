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
            _costumerService = costumerService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult PostNewCostumer(CostumerBase costumer)
        {
            try
            {
                _costumerService.ProcessNewCostumer(costumer);
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
            return Ok("Inserção feita com sucesso!");
        }
    }
}