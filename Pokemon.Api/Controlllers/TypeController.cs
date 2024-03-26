using Microsoft.AspNetCore.Mvc;
using Pokemon.Core.Interfaces.IServices;
using Pokemon.Core.Services;

namespace Pokemon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ILogger<TypeController> _logger;
        private readonly ITypeService _typeService;

        public TypeController(ILogger<TypeController> logger, ITypeService typeService)
        {
            _logger = logger;
            _typeService = typeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? pageNumber, int? pageSize)
        {
            try
            {
                int pageSizeValue = pageSize ?? 1;
                int pageNumberValue = pageNumber ?? 1;
                //Get peginated data
                var customers = await _typeService.GetTypes();

                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving pokemon data.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Core.Entities.General.Type model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = await _typeService.Create(model);
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

        // PUT api/type/[id]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Core.Entities.General.Type model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _typeService.Update(id, model);
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

        // DELETE api/type/[id]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _typeService.Delete(id);
                return Ok();
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