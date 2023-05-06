using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly_C.Horizon.Models.DTOs.ClientServicing.Requests;
using Polly_C.Horizon.Service.ClientServicing.Interfaces;

namespace Polly_C.Horizon.WebAPI.ClientServicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryDetailsController : ControllerBase
    {
        private readonly IClientServicingService _clientServicingService;
        private readonly ILogger<BeneficiaryDetailsController> _logger;

        public BeneficiaryDetailsController(IClientServicingService clientServicingService, ILogger<BeneficiaryDetailsController> logger)
        {
            _clientServicingService = clientServicingService;
            _logger = logger;
        }

        [HttpPost("policyBeneficiaryDetails")]
        public async Task<IActionResult> GetPolicyBeneficiaryDetails([FromBody]BeneficiaryDetailsRequest request)
        {
            try
            {
                return Ok(await _clientServicingService.GetBeneficiaryDetails(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Executing PolicyBeneficiaryDetails.");
                return StatusCode(StatusCodes.Status500InternalServerError,ex.InnerException is null ? ex.Message : ex.InnerException.Message);  
            }
        }
    }
}
