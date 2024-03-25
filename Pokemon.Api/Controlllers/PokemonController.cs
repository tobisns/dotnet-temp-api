using Microsoft.AspNetCore.Mvc;
using Pokemon.Core.Interfaces.IServices;
using Pokemon.Core.Services;

namespace Pokemon.API.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Get()
        {
            try
            {
                //Get peginated data
                var customers = await _pokemonService.GetPokemons();

                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving weather forecast.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }

    // GET: api/customer/paginated
}