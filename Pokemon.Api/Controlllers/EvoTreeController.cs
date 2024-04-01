using Microsoft.AspNetCore.Mvc;
using Pokemon.Core.Interfaces.IServices;
using Pokemon.Core.Services;

namespace Pokemon.API.Controllers
{
    [Route("evolution_tree")]
    [ApiController]
    public class EvoTreeController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly IEvoTreeService _evoTreeService;

        public EvoTreeController(ILogger<PokemonController> logger, IEvoTreeService evoTreeService)
        {
            _logger = logger;
            _evoTreeService = evoTreeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Core.Entities.Business.EvoCreate model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = await _evoTreeService.Create(model);
                    return Ok(data);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while adding the customer");
                    string message = $"An error occurred while adding the customer- {ex.Message}";

                    return StatusCode(StatusCodes.Status500InternalServerError, message);
                }
            }

            return StatusCode(StatusCodes.Status400BadRequest, "Please input all required data");
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(int id, Core.Entities.Business.EvoCreate model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = await _evoTreeService.Update(id, model);
                    return Ok(data);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while adding the customer");
                    string message = $"An error occurred while adding the customer- {ex.Message}";

                    return StatusCode(StatusCodes.Status500InternalServerError, message);
                }
            }

            return StatusCode(StatusCodes.Status400BadRequest, "Please input all required data");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, Core.Entities.Business.ListPokemon model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = await _evoTreeService.Delete(id, model);
                    return Ok(data);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while adding the customer");
                    string message = $"An error occurred while adding the customer- {ex.Message}";

                    return StatusCode(StatusCodes.Status500InternalServerError, message);
                }
            }

            return StatusCode(StatusCodes.Status400BadRequest, "Please input all required data");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = await _evoTreeService.Get(id);
                    return Ok(data);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while adding the customer");
                    string message = $"An error occurred while adding the customer- {ex.Message}";

                    return StatusCode(StatusCodes.Status500InternalServerError, message);
                }
            }

            return StatusCode(StatusCodes.Status400BadRequest, "Please input all required data");
        }
    }
}
