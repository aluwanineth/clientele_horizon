using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.DTOs.ClientServicing.Results
{
    public class CustomerPolicyInfoResult
    {
        public int PolicyNo { get; set; }

        public int IFANo { get; set; }

        public string ProductDescr { get; set; }

        public string PolicyStatus { get; set; }

        public short StatusCd { get; set; }

        public DateTime DateOfCommencement { get; set; }

        public string Payer { get; set; }

        public decimal PolicyPremium { get; set; }

        public DateTime BilledTo { get; set; }

        public DateTime PaidTo { get; set; }

        public int? PremiumCount { get; set; }

        public int PremiumFrequency { get; set; }

        public string SalesPerson { get; set; }

        public string DebiCheckStatus { get; set; }

        public string LegacyPolicyNo { get; set; }

        public DateTime StatusDate { get; set; }
    }
}
