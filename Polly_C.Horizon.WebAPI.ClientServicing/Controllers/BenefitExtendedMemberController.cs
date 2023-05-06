using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly_C.Horizon.Models.DTOs.ClientServicing.Requests;
using Polly_C.Horizon.Service.ClientServicing.Interfaces;

namespace Polly_C.Horizon.WebAPI.ClientServicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitExtendedMemberController : ControllerBase
    {
        private readonly IClientServicingService _clientServicingService;
        private readonly ILogger<BenefitExtendedMemberController> _logger;

        public BenefitExtendedMemberController(IClientServicingService clientServicingService, ILogger<BenefitExtendedMemberController> logger)
        {
            _clientServicingService = clientServicingService;
            _logger = logger;
        }

        [HttpPost("policyBenefitExtendedMember")]
        public async Task<IActionResult> GetPolicyBenefitExtendedMember([FromBody]BenefitExtendedMemberRequest request) 
        {
            try
            {
                return Ok(await _clientServicingService.GetBenefitExtendedMemberDetails(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Executing PolicyBenefitExtendedMember.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
