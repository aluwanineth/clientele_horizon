using Microsoft.AspNetCore.Mvc;
using Polly_C.Horizon.Models.DTOs.ClientServicing.Requests;
using Polly_C.Horizon.Service.ClientServicing.Interfaces;

namespace Polly_C.Horizon.WebAPI.ClientServicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicySearchController : ControllerBase
    {
        private readonly IClientServicingService _clientServicingService;
        private readonly ILogger<PolicySearchController> _logger;

        public PolicySearchController(IClientServicingService clientServicingService, ILogger<PolicySearchController> logger)
        {
            _clientServicingService = clientServicingService;
            _logger = logger;
        }

        [HttpGet]
        [Route("Ping")]
        public bool Ping()
        {
            return true;
        }

        [HttpPost]
        [Route("advancedPersonSearch")]
        public async Task<IActionResult> AdvancedPersonSearch([FromBody] AdvancedPersonSearchRequest request)
        {
            try
            {
                return Ok(await _clientServicingService.AdvancedPersonSearch(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Executing advancedPersonSearch.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("personSearch")]
        public async Task<IActionResult> PersonSearch([FromBody] PersonSearchRequest request)
        {
            try
            {
                return Ok(await _clientServicingService.PersonSearch(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Executing advancedPersonSearch.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
