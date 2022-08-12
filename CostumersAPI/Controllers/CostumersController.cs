using Microsoft.AspNetCore.Mvc;
using CostumersAPI.Costumer;
using CostumersAPI.Services;

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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostNewCostumer(CostumerBase costumer)
        {
            if (!costumer.Email.Equals(costumer.EmailConfirmation))
                return BadRequest("Confirma��o de Email divergente");
            try
            {
                _costumerService.SaveNewCostumer(costumer);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception while saving new costumer: {e}");
                return Problem("N�o foi poss�vel completar a solicita��o");
            }
            return Ok("Inser��o feita com sucesso!");
        }
    }
}