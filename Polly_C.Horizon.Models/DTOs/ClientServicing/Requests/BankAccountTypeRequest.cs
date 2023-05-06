using Polly_C.Horizon.Models.DTOs.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.DTOs.ClientServicing.Requests
{
    public class BankAccountTypeRequest
    {
        public byte? BankAccTypeCD { get; set; }

        public string BankAccTypeDesc { get; set; }

        public string BankAccTypeRegEx { get; set; }

        public short? DispSeq { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? LastChanged { get; set; }

        public string UserID { get; set; }
    }
}
