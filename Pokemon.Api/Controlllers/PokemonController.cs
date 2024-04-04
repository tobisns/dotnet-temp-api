using Microsoft.AspNetCore.Mvc;
using Pokemon.Core.Interfaces.IServices;
using Pokemon.Core.Services;

namespace Pokemon.API.Controllers
{
    [Route("pokemons")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly IPokemonService _pokemonService;

        public PokemonController(ILogger<PokemonController> logger, IPokemonService pokemonService)
        {
            _logger = logger;
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? offset, int? limit, string? query)
        {
            try
            {
                int pageSizeValue = limit ?? 1;
                int pageNumberValue = offset ?? 0;
                string queryValue = query ?? "";
                //Get peginated data
                var customers = await _pokemonService.GetPokemonsPaginated(pageNumberValue, pageSizeValue, queryValue);

                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving pokemon data.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Core.Entities.Business.Pokemon model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = await _pokemonService.Create(model);
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

        // PUT api/pokemon/[name]
        [HttpPut("{name}")]
        public async Task<IActionResult> Edit(string name, Core.Entities.Business.Pokemon model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _pokemonService.Update(name, model);
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while updating the customer");
                    string message = $"An error occurred while updating the customer- {ex.Message}";

                    return StatusCode(StatusCodes.Status500InternalServerError, message);
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, "Please input all required data");
        }

        // DELETE api/pokemon/[name]
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            try
            {
                await _pokemonService.Delete(name);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the customer");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the customer- " + ex.Message);
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetDetails(string name)
        {
            try
            {
                var _data = await _pokemonService.GetDetails(name);
                return Ok(_data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the customer");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the customer- " + ex.Message);
            }
        }
    }

    

    // GET: api/customer/paginated
}