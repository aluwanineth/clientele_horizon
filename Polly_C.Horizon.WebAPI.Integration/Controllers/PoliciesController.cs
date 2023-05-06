using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polly_C.Horizon.Models.Enums.v1;
using Polly_C.Horizon.Models.Integration;
using Polly_C.Horizon.Models.Integration.v1;
using Polly_C.Horizon.Models.Policy;
using Polly_C.Horizon.Utilities;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Polly_C.Horizon.Data.Polly_C.Models;

namespace Polly_C.Horizon.WebAPI.Integration.Controllers
{
    [Authorize]
    public class PoliciesController : ControllerBase
    {
        private readonly Polly_CContext _context;
        private readonly ILogger<PoliciesController> _logger;
        private IPolicyRepository _policyRepository;
        public PoliciesController(ILogger<PoliciesController> logger, IPolicyRepository policyRepository, Polly_CContext context)
        {
            _logger = logger;
            _policyRepository = policyRepository;
            _context = context;
        }

        [Authorize(Roles = "PolicyCreate")]
        [HttpPost]
        [Route("api/v1.0/policies")]
        public async Task<IActionResult> Policy([FromBody] MessagePolicyV1 policy)
        {
            try
            {
                Guid? messageId = null;

                if (!ModelState.IsValid)
                {
                    return HandleInvalidMessage(messageId);
                }
                else
                {
                    bool hasErrors = false;
                    string statusMessage = string.Empty;

                    var jsonPolicy = string.Empty;
                    var options = new JsonSerializerOptions();
                    options.Converters.Add(new JsonStringEnumConverter());
                    jsonPolicy = JsonSerializer.Serialize(policy,options);

                    _logger.LogInformation($"Request received:  {jsonPolicy}");

                    if (policy?.Policy?.Entities == null || policy.Policy?.Product == null || policy.Policy?.Entities == null)
                    {
                        return UnprocessableEntity(new ResponseMessage { CorrelationId = policy?.MessageId, Message = "Policy is invalid" });
                    }

                    foreach (var entity in policy.Policy.Entities)
                    {
                        if (!IsLegalNumberValid(entity.PersonalDetails, ref statusMessage))
                        {
                            hasErrors = true;
                        }
                    }
                    if (hasErrors)
                    {
                        return new BadRequestObjectResult(new ResponseMessage { CorrelationId = policy.MessageId, Message = statusMessage.Trim() });
                    }


                    if (!(await _policyRepository.CreateNewPolicyV1(policy)))
                    {
                        _logger.LogError($"Integration Create New Policy {statusMessage}");
                        return new BadRequestObjectResult(new ResponseMessage { CorrelationId = policy.MessageId, Message = statusMessage.Trim() });
                    }

                    return Accepted(new ResponseMessage { CorrelationId = policy.MessageId, Message = "Received" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Integration Create New Policy");
                return StatusCode(500, new ResponseMessage { CorrelationId = policy?.MessageId, Message = "Unable to process message." });
            }
        }

        private IActionResult HandleInvalidMessage(Guid? messageId)
        {
            var modelStateJson = string.Empty;
            try
            {
                var serializableModelState = new SerializableError(ModelState);
                modelStateJson = JsonSerializer.Serialize(serializableModelState);
                _logger.LogError(modelStateJson);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Integration Create New Policy: Model is invalid");
            }
            return UnprocessableEntity(new ResponseMessage { CorrelationId = messageId, Message = modelStateJson });
        }

        private bool IsLegalNumberValid(PersonalDetailsV1 personalDetails, ref string statusMessage)
        {
            if (personalDetails == null) { statusMessage = $"{statusMessage} Personal Details not found."; return false; }

            if (personalDetails.LegalReferenceNumberType == LegalReferenceNumberTypeV1.SAIDNumber && !string.IsNullOrEmpty(personalDetails.MaskedLegalReferenceNumber))
            { }
            else if (personalDetails.LegalReferenceNumberType == LegalReferenceNumberTypeV1.SAIDNumber && !FieldValidation.IsValidSAIDNumber(personalDetails.LegalReferenceNumber))
            {
                statusMessage = $"{statusMessage} SA ID Number is invalid.";
                return false;
            }

            if (personalDetails.LegalReferenceNumberType == LegalReferenceNumberTypeV1.PassportNumber && personalDetails.DoB == null)
            {
                statusMessage = $"{statusMessage} Date of Birth must be supplied if passport number is used.";
                return false;
            }
            if (personalDetails.LegalReferenceNumberType == LegalReferenceNumberTypeV1.CompanyRegistrationNumber && string.IsNullOrEmpty(personalDetails.FullName))
            {
                statusMessage = $"{statusMessage} Full name must be supplied if company registration number is used.";
                return false;
            }

            return true;
        }
    }
}
