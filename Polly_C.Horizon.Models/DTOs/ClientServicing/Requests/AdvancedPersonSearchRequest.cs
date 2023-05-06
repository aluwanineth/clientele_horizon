using Polly_C.Horizon.Models.DTOs.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.DTOs.ClientServicing.Requests
{
    public class AdvancedPersonSearchRequest
    {
        public string? EncashmentNo { get; set; } = string.Empty;

        public string? BusRegNo { get; set; } = string.Empty;

        public string? AppFormNo { get; set; } = string.Empty;

        public string? EmailAddress { get; set; } = string.Empty;

        public string? BusinessName { get; set; } = string.Empty;

        public string? FullName { get; set; } = string.Empty;
    }
}
