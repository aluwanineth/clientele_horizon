namespace Polly_C.Horizon.Models.DTOs.ClientServicing.Results
{
    public class PersonSearchResult
    {
        public int? EntityID { get; set; }

        public int EntityNo { get; set; }

        public string EntityName { get; set; }

        public string EntitySurname { get; set; }

        public DateTime? EntityDOB { get; set; }

        public string LegalRefNo { get; set; }

        public string LegalRefNoType { get; set; }

        public string EmailAddress { get; set; }

        public string CellphoneNumber { get; set; }

        public string LegacyPolicyNo { get; set; }

        public int? PolicyNo { get; set; }

        public string Status { get; set; }

        public string PlanTypeDescr { get; set; }

        public DateTime? StatusDate { get; set; }

        public DateTime? DateOfCommencement { get; set; }

        public decimal? PremiumAmt { get; set; }

        public string SalesPerson { get; set; }

        public string RewardStatus { get; set; }

        public string DebiCheckStatus { get; set; }

        public string Agency { get; set; }

        public string Payor { get; set; }

        public string EntityFullname { get; set; }
    }
}