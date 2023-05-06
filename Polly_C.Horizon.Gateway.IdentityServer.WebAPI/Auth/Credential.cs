using System.ComponentModel.DataAnnotations;

namespace Polly_C.Horizon.Gateway.IdentityServer.WebAPI.Auth
{
    public class Credential
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
