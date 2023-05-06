using Polly_C.Horizon.Models.DTOs.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.DTOs.ClientServicing.Requests
{
    public class PersonSearchRequest
    {
        public string? PolicyNo { get; set; }

        public string? LegPolNo { get; set; }

        public string? IFANo { get; set; }

        public string? ClientEntityNo { get; set; }

        public string? LegalRefNo { get; set; }

        public string? CellNo { get; set; }
    }
}
