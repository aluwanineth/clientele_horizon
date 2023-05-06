using Microsoft.AspNetCore.Mvc;
using Polly_C.Horizon.Models.DTOs.Account;
using Polly_C.Horizon.WebAPI.Authentication.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Polly_C.Horizon.WebAPI.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
     
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
           
        }
    
        // POST api/<ValuesController>
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Post([FromBody] AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var results = await _accountService.AuthenticateAsync(request, GenerateIPAddress());
            return Ok(results);
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh(TokenModel tokenApiModel)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RefreshToken(tokenApiModel, origin ));
        }

        private string GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
