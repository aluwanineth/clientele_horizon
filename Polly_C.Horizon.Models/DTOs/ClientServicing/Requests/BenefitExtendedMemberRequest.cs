using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.DTOs.ClientServicing.Requests
{
    public class BenefitExtendedMemberRequest
    {
        public BenefitExtendedMemberRequest() { }

        public int? PolicyNO { get; set; }

        public DateTime? EffectiveDate { get; set; }
    }
}
