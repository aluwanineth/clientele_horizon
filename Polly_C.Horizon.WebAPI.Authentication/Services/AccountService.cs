using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Polly_C.Horizon.Models.DTOs.Account;
using Polly_C.Horizon.Models.Wrappers;
using Polly_C.Horizon.Utilities.Exceptions;
using Polly_C.Horizon.WebAPI.Authentication.Controllers;
using Polly_C.Horizon.WebAPI.Authentication.Helpers;
using Polly_C.Horizon.WebAPI.Authentication.Interfaces;
using Serilog;
using System.Data.Common;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Polly_C.Horizon.WebAPI.Authentication.Services
{
    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> _logger;
        private readonly IOptions<Models.DTOs.Account.Domain> _domain;
        private readonly JWTSettings _jwtSettings;
        public AccountService(ILogger<AccountService> logger, IOptions<Models.DTOs.Account.Domain> options, IOptions<JWTSettings> jwtSettings)
        {
            _logger = logger;
            _domain = options;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            AuthenticationResponse authenticationResponse = new();
            try
            {
                var username = (request.Username).Split('@')[0];
                if (GetDomainName(request.Username) == _domain.Value.Name)
                {
                    var user = GetUser(username, request.Password);

                    if (user != null)
                    {
                        var refreshToken = GenerateRefreshToken(ipAddress);
                        JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
                        authenticationResponse.IsLogin = true;
                        authenticationResponse.Username = request.Username;
                        authenticationResponse.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                        authenticationResponse.RefreshToken = refreshToken.Token;
                    }
                    else
                    {
                        _logger.LogError($"User: {request.Username} not found");
                        throw new ApiException($"Invalid Credentials for '{request.Username}'.");
                    }
                }
                else
                {
                    throw new ApiException($"Other domain not implemented '{request.Username}'.");
                }
            } 
        
            catch (AccessViolationException ex)
            {
                _logger.LogError($"Error: {ex.Message}, Inner Exeption: {ex.InnerException}, StackTrace: {ex.StackTrace}");
                throw new ApiException($"Invalid Credentials for '{request.Username}'.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}, Inner Exeption: {ex.InnerException}, StackTrace: {ex.StackTrace}");
                throw new ApiException($"Invalid Credentials for '{request.Username}'.");
            }
            return new Response<AuthenticationResponse>(authenticationResponse, $"Authenticated {request.Username}"); ;
        }

        public async Task<Response<TokenModel>> RefreshToken(TokenModel tokenModel, string ipAddress)
        {
            
            if (tokenModel == null)
                throw new ApiException($"Invalid client request");
            string? accessToken = tokenModel.AccessToken;
            string? refreshToken = tokenModel.RefreshToken;
            var principal = GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                throw new ApiException("Invalid access token or refresh token");
            }
            string userNameOrEmailAddress = string.Empty;
           
            foreach(var claim in principal.Claims) 
            { 
                if(claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")
                {
                    userNameOrEmailAddress = claim.Value;
                }
            }

            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, _domain.Value.Name);
            var userPrincipal = UserPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, userNameOrEmailAddress);

            if (userPrincipal == null)
            {
                userPrincipal = UserPrincipal.FindByIdentity(principalContext, IdentityType.UserPrincipalName, userNameOrEmailAddress);

                if (userPrincipal == null)
                {
                    throw new ApiException("Unknown user: " + userNameOrEmailAddress);
                }
            }

            var jwtSecurityToken = await GenerateJWToken(userPrincipal);
            var newAccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var newRefreshToken = GenerateRefreshToken(ipAddress);
            
            TokenModel response = new TokenModel
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token
            };
            return new Response<TokenModel>(response, $"Refresh token {userPrincipal}");
        }

        private string GetDomainName(string username)
        {
            return Regex.Match(username, @"@([\w-]+).").Groups[1].Value;
        }

        private async Task<JwtSecurityToken> GenerateJWToken(UserPrincipal user)
        {
            var userClaims = new List<Claim>();
            userClaims.Add(new Claim(JwtClaimTypes.Subject, user.GivenName));
            userClaims.Add(new Claim(JwtClaimTypes.Name, user.GivenName));
           
            string ipAddress = IpHelper.GetIpAddress();

            var groups = user.GetGroups();
            var roles = groups.Select(x => new Claim(JwtClaimTypes.Role, x.Name));

            var roleClaims = new List<Claim>();
            foreach (var role in roles) 
            {
                roleClaims.Add(new Claim("roles",role.Value));
            }

            var claims = new[]
             {
                new Claim(JwtRegisteredClaimNames.Sub, user.GivenName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.UserPrincipalName),
                //new Claim("uid", user.),
                new Claim("ip", ipAddress)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        private string RandomTokenString()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;

        }

        private UserPrincipal GetUser(string username, string password)
        {
            string domain = _domain.Value.Name;
            UserPrincipal user = null;
            PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain);
            
            bool isValid = pc.ValidateCredentials(username, password, ContextOptions.ServerBind);
            if (isValid)
            {
                user = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, username);
            }
            return user;
            
        } 
    }

   
}
