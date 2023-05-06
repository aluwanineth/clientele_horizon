using System.ComponentModel.DataAnnotations;

namespace Polly_C.Horizon.Gateway.IdentityServer.WebAPI.Auth
{
    public class ManageUser
    {
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string? Role { get; set; }
    }
}
