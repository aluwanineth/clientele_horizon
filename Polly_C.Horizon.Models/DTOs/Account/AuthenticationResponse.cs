using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.DTOs.Account
{
    public class AuthenticationResponse
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? JWToken { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }
        public bool IsLogin { get; set; } = false;
    }
}
