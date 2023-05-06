﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.DTOs.ClientServicing.Results
{
    public class GetPolicyAndMainMemberDetailsResult
    {
        public int Policy_NO { get; set; }
        public int EntityNo { get; set; }
        public string Legacy_Pol_No { get; set; }
        public decimal? AnnualIncrease { get; set; }
        public DateTime DateOfCommencement { get; set; }
        public DateTime? ReInstatedDate { get; set; }
        public DateTime? LapsedDate { get; set; }
        public string Venue { get; set; }
        public string SalesPerson { get; set; }
        public int CampaignCode { get; set; }
        public int PolicyFee { get; set; }
        public DateTime CaptureDate { get; set; }
        public int PreferedCommunicationMethod { get; set; }
        public string MasterContract { get; set; }
        public string Title { get; set; }
        public int? TitleID { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string LegalRefNo { get; set; }
        public string LegalNumberType { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string FaxNumber { get; set; }
        public string HomeNumber { get; set; }
        public bool? PreferredHome { get; set; }
        public string EmailAddress { get; set; }
        public bool? PreferredEmail { get; set; }
        public string CellNumber { get; set; }
        public bool? PreferredCell { get; set; }
        public string PhysicalAddress1 { get; set; }
        public string PhysicalAddress2 { get; set; }
        public string PhysicalSuburb { get; set; }
        public string PhysicalTown { get; set; }
        public string PhysicalPostalCode { get; set; }
        public string PostalAddress1 { get; set; }
        public string PostalAddress2 { get; set; }
        public string PostalSuburb { get; set; }
        public string PostalTown { get; set; }
        public string PostalPostalCode { get; set; }
        public int? GenderCD { get; set; }
        public int SmokerCD { get; set; }
        public DateTime LastBillingDate { get; set; }
        public DateTime LastPaidDate { get; set; }
        public DateTime? NextBillingDate { get; set; }
        public decimal? PolicyPremiumAmount { get; set; }
        public int? PremiumCount { get; set; }
        public string PaymentFrequency { get; set; }
    }
}
