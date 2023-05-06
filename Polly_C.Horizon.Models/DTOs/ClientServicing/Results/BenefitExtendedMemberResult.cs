using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.DTOs.ClientServicing.Results
{
    public class BenefitExtendedMemberResult
    {
        public BenefitExtendedMemberResult() { }

        public int Benefit { get; set; }

        public string BenefitDesctiption { get; set; }

        public DateTime DOC { get; set; }

        public decimal Premium { get; set; }

        public string SumAssured { get; set; }

        public string FirstName { get; set; }

        public string SurName { get; set; }

        public string Relation { get; set; }

        public string IDNumber { get; set; }

        public decimal? CoveredAmount { get; set; }

        public decimal? PremiumAmount { get; set; }

        public string WaitingPeriod { get; set; }

        public DateTime? DOB { get; set; }

        public string STATUS { get; set; }
    }
}
