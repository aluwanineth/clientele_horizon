using Polly_C.Horizon.Models.DTOs.Account;
using Polly_C.Horizon.Models.Wrappers;
using System.DirectoryServices.AccountManagement;

namespace Polly_C.Horizon.WebAPI.Authentication.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<TokenModel>> RefreshToken(TokenModel tokenModel, string ipAddress);
    }
}
