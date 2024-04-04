using Microsoft.AspNetCore.Mvc;
using Pokemon.Core.Interfaces.IServices;

namespace Pokemon.API.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;

        public UserController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet("authenticate")]
        public IActionResult Get()
        {
            var responseData = new { is_admin = true };
            return Ok(responseData);
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            var responseData = new { is_admin = true };
            return Ok(responseData);
        }
    }
}