using Polly_C.Horizon.Models.DTOs.Wrappers;

namespace Polly_C.Horizon.Models.DTOs.ClientServicing.Requests
{
    public class BankRequest
    {
        public int? BankID { get; set; }

        public string BankName { get; set; }

        public string BankShortName { get; set; }

        public short? DispSeq { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? LastChanged { get; set; }

        public string UserID { get; set; }
    }
}
