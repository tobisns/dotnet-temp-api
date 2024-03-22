using Microsoft.AspNetCore.Mvc;
using Pokemon.Core.Interfaces.IServices;

namespace Pokemon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherController(ILogger<WeatherController> logger, IWeatherService weatehrService)
        {
            _logger = logger;
            _weatherService = weatehrService;
        }

        [HttpGet("forecast")]
        public async Task<IActionResult> Get()
        {
            try
            {
                //Get peginated data
                var customers = await _weatherService.GetWeatherForecast();

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