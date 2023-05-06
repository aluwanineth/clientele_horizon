using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.DTOs.ClientServicing.Results
{
    public class BeneficiaryDetailsResult
    {
        public BeneficiaryDetailsResult() { }
        public string FirstName { get; set; }

        public string SurName { get; set; }

        public string Relation { get; set; }

        public string IDNumber { get; set; }

        public int? CoveredAmount { get; set; }

        public decimal? Allocation { get; set; }

        public int? DateCeded { get; set; }

        public DateTime? DOB { get; set; }

        public string STATUS { get; set; }
    }
}
