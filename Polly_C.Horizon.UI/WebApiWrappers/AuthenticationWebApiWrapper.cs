using Azure.Core;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using Polly_C.Horizon.Models.DTOs.Account;
using Polly_C.Horizon.Models.Enums;
using Polly_C.Horizon.Models.Wrappers;
using Polly_C.Horizon.UI.DTOs;
using Polly_C.Horizon.UI.WebApiWrapperInterfaces.Utilities;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Polly_C.Horizon.UI.Wrappers
{
    public class AuthenticationWebApiWrapper : WebApiWrapperInterfaces.IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly IHttpClientWrapper _httpClientService;

        public AuthenticationWebApiWrapper(HttpClient client, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage, IHttpClientWrapper httpClientService)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
            _httpClientService = httpClientService;
        }
    
        public async Task<Response<AuthenticationResponse>>AuthenticateAsync(AuthenticationRequest request)
        {
            var result = await _httpClientService.postAsync<Response<AuthenticationResponse>, AuthenticationRequest> (Controllers.Authentication, "authenticate", request);
            
            await _localStorage.SetItemAsync("authToken", result.Data.JWToken);
            await _localStorage.SetItemAsync("refreshToken", result.Data.RefreshToken);
            await _localStorage.SetItemAsync("username", result.Data.Username);
            ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Data.JWToken);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Data.JWToken);

            return result;
        }

        public async Task<string> RefreshToken()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var refreshToken = await _localStorage.GetItemAsync<string>("refreshToken");

            var result = await _httpClientService.postAsync<Response<TokenModel>, TokenModel>(Controllers.Authentication, "refresh", (new TokenModel { AccessToken = token, RefreshToken = refreshToken }));
            
            await _localStorage.SetItemAsync("authToken", result.Data.AccessToken);
            await _localStorage.SetItemAsync("refreshToken", result.Data.RefreshToken);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Data.AccessToken);
            return result.Data.AccessToken;
        }
    }
}
