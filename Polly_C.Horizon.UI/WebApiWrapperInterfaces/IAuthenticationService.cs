using Polly_C.Horizon.Models.DTOs.Account;
using Polly_C.Horizon.Models.Wrappers;

namespace Polly_C.Horizon.UI.WebApiWrapperInterfaces
{
    public interface IAuthenticationService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request);
        Task<string> RefreshToken();
    }
}
