using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Polly_C.Horizon.Models.DTOs.ClientServicing.Requests;
using Polly_C.Horizon.Models.DTOs.ClientServicing.Results;
using Polly_C.Horizon.Models.Wrappers;
using Polly_C.Horizon.Service.ClientServicing.Interfaces;

namespace Polly_C.Horizon.WebAPI.ClientServicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyDetailsController : ControllerBase
    {
        private readonly IClientServicingService _clientServicingService;
        private readonly ILogger<BeneficiaryDetailsController> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;
        public PolicyDetailsController(IClientServicingService clientServicingService, ILogger<BeneficiaryDetailsController> logger,
            IMemoryCache memoryCache)
        {
            _clientServicingService = clientServicingService;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        [HttpPost("getPolicyAndMainMemberDetails")]
        public async Task<IActionResult> GetPolicyAndMainMemberDetails([FromBody] GetPolicyAndMainMemberDetailsRequest request)
        {
            try
            {
                return Ok(await _clientServicingService.GetPolicyAndMainMemberDetails(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Executing PolicyAndMainMemberDetails.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
            }
        }

        [HttpPost("getPaymentFrequentLookups")]
        public async Task<IActionResult> GetPaymentFrequentLookups([FromBody] PaymentFrequentSelectRequest request)
        {
            try
            {
                string paymentFrequentResultListCacheKey = "paymentFrequentList";
                if (_memoryCache.TryGetValue(paymentFrequentResultListCacheKey, out Response<List<PaymentFrequentSelectResult>> paymentFrequentResult))
                {
                    _logger.Log(LogLevel.Information, "paymentFrequent list found in cache.");
                }
                else
                {
                    _logger.Log(LogLevel.Information, "paymentFrequent list not found in cache. Fetching from database.");
                    paymentFrequentResult = await _clientServicingService.GetPaymentFrequentLookups(request);
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromHours(_configuration.GetValue<int>("MemoryCache:SlidingExpiration")))
                            .SetAbsoluteExpiration(TimeSpan.FromHours(_configuration.GetValue<int>("MemoryCache:AbsoluteExpiration")))
                            .SetPriority(CacheItemPriority.Normal)
                            .SetSize(_configuration.GetValue<int>("MemoryCache:Size"));
                    _memoryCache.Set(paymentFrequentResultListCacheKey, paymentFrequentResult, cacheEntryOptions);
                }
                return Ok(paymentFrequentResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Executing PaymentFrequentLookups.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
            }
        }

        [HttpPost("getsSmokerLookups")]
        public async Task<IActionResult> GetSmokerLookups([FromBody] SmokerSelectRequest request)
        {
            try
            {
                string smokerSelectResultListCacheKey = "smokerSelectList";

                if (_memoryCache.TryGetValue(smokerSelectResultListCacheKey, out Response<List<SmokerSelectResult>> smokerSelectResult))
                {
                    _logger.Log(LogLevel.Information, "smokerSelect list found in cache.");
                }
                else
                {
                    _logger.Log(LogLevel.Information, "smokerSelect list not found in cache. Fetching from database.");
                    smokerSelectResult = await _clientServicingService.GetSmokerLookups(request);
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                             .SetSlidingExpiration(TimeSpan.FromHours(_configuration.GetValue<int>("MemoryCache:SlidingExpiration")))
                            .SetAbsoluteExpiration(TimeSpan.FromHours(_configuration.GetValue<int>("MemoryCache:AbsoluteExpiration")))
                            .SetPriority(CacheItemPriority.Normal)
                            .SetSize(_configuration.GetValue<int>("MemoryCache:Size"));
                    _memoryCache.Set(smokerSelectResultListCacheKey, smokerSelectResult, cacheEntryOptions);
                }
                return Ok(smokerSelectResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Executing SmokerLookups.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
            }
        }

        [HttpPost("getGendersLookups")]
        public async Task<IActionResult> GetGendersLookups([FromBody] GenderSelectRequest request)
        {
            try
            {
                string genderSelectResultListCacheKey = "genderSelectList";

                if (_memoryCache.TryGetValue(genderSelectResultListCacheKey, out Response<List<GenderSelectResult>> genderSelectResult))
                {
                    _logger.Log(LogLevel.Information, "genderSelect list found in cache.");
                }
                else
                {
                    _logger.Log(LogLevel.Information, "genderSelect list not found in cache. Fetching from database.");
                    genderSelectResult = await _clientServicingService.GetGendersLookups(request);
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                             .SetSlidingExpiration(TimeSpan.FromHours(_configuration.GetValue<int>("MemoryCache:SlidingExpiration")))
                            .SetAbsoluteExpiration(TimeSpan.FromHours(_configuration.GetValue<int>("MemoryCache:AbsoluteExpiration")))
                            .SetPriority(CacheItemPriority.Normal)
                            .SetSize(_configuration.GetValue<int>("MemoryCache:Size"));
                    _memoryCache.Set(genderSelectResultListCacheKey, genderSelectResult, cacheEntryOptions);
                }
                return Ok(genderSelectResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Executing GendersLookups.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
            }
        }

        [HttpPost("getTittlesLookups")]
        public async Task<IActionResult> GetGendersLookups([FromBody] TitleSelectRequest request)
        {
            try
            {
                string tittleSelectResultListCacheKey = "tittleSelectList";

                if (_memoryCache.TryGetValue(tittleSelectResultListCacheKey, out Response<List<TitleSelectResult>> tittleSelectResult))
                {
                    _logger.Log(LogLevel.Information, "tittleSelect list found in cache.");
                }
                else
                {
                    _logger.Log(LogLevel.Information, "tittleSelect list not found in cache. Fetching from database.");
                    tittleSelectResult = await _clientServicingService.GetTittlesLookups(request);
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                             .SetSlidingExpiration(TimeSpan.FromHours(_configuration.GetValue<int>("MemoryCache:SlidingExpiration")))
                            .SetAbsoluteExpiration(TimeSpan.FromHours(_configuration.GetValue<int>("MemoryCache:AbsoluteExpiration")))
                            .SetPriority(CacheItemPriority.Normal)
                            .SetSize(_configuration.GetValue<int>("MemoryCache:Size"));
                    _memoryCache.Set(tittleSelectResultListCacheKey, tittleSelectResult, cacheEntryOptions);
                }
                return Ok(tittleSelectResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Executing TittlesLookups.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
            }
        }

        [HttpPost("getBankAccountTypeLookups")]
        public async Task<IActionResult> GetBankAccountTypeLookups([FromBody] BankAccountTypeRequest request)
        {
            try
            {
                string bankAccountTypeListCacheKey = "bankAccountTypeList";

                if (_memoryCache.TryGetValue(bankAccountTypeListCacheKey, out Response<List<BankAccountTypeResult>> bankAccountTypeResult))
                {
                    _logger.Log(LogLevel.Information, "bankAccountType list found in cache.");
                }
                else
                {
                    _logger.Log(LogLevel.Information, "bankAccountType list not found in cache. Fetching from database.");
                    bankAccountTypeResult = await _clientServicingService.GetBankAccountTypeLookups(request);
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                             .SetSlidingExpiration(TimeSpan.FromHours(_configuration.GetValue<int>("MemoryCache:SlidingExpiration")))
                            .SetAbsoluteExpiration(TimeSpan.FromHours(_configuration.GetValue<int>("MemoryCache:AbsoluteExpiration")))
                            .SetPriority(CacheItemPriority.Normal)
                            .SetSize(_configuration.GetValue<int>("MemoryCache:Size"));
                    _memoryCache.Set(bankAccountTypeListCacheKey, bankAccountTypeResult, cacheEntryOptions);
                }
                return Ok(bankAccountTypeResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Executing GetBankAccountTypeLookups.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("getBankLookups")]
        public async Task<IActionResult> GetBankLookups([FromBody] BankRequest request)
        {
            try
            {
                string bankListCacheKey = "bankList";

                if (_memoryCache.TryGetValue(bankListCacheKey, out Response<List<BankResult>> bankResult))
                {
                    _logger.Log(LogLevel.Information, "bank list found in cache.");
                }
                else
                {
                    _logger.Log(LogLevel.Information, "bank list not found in cache. Fetching from database.");
                    bankResult =  await _clientServicingService.GetBankLookups(request);
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                             .SetSlidingExpiration(TimeSpan.FromHours(_configuration.GetValue<int>("MemoryCache:SlidingExpiration")))
                            .SetAbsoluteExpiration(TimeSpan.FromHours(_configuration.GetValue<int>("MemoryCache:AbsoluteExpiration")))
                            .SetPriority(CacheItemPriority.Normal)
                            .SetSize(_configuration.GetValue<int>("MemoryCache:Size"));
                    _memoryCache.Set(bankListCacheKey, bankResult, cacheEntryOptions);
                }
                return Ok(bankResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Executing GetBankLookups.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
