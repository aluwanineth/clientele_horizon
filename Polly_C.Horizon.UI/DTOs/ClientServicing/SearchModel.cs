using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Polly_C.Horizon.UI.DTOs.ClientServicing
{
    public class SearchModel
    {
        public string? PolicyNo { get; set; }
        
        public string? LegPolNo { get; set; }
        
        public string? IFANo { get; set; }
        
        public string? ClientEntityNo { get; set; }
        
        public string? IDPassportNo { get; set; }
        
        public string? ClaimNo { get; set; }
        
        public string? CellphoneNo { get; set; }
        
        public string? PersonName { get; set; }
        
        public string? PersonSurname { get; set; }
        
        public string? LegacyPolicyNo { get; set; }
        
        public string? ApplicationFormNo { get; set; }
        
        public string? LegalRefNo { get; set; }
        
        public string? CellNo { get; set; }

        public string? EncashmentNo { get; set; }

        public string? BusRegNo { get; set; }

        public string? AppFormNo { get; set; }

        public string? EmailAddress { get; set; }

        public string? BusinessName { get; set; }

        public string? FullName { get; set; }
    }
}
