using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.DTOs.ClientServicing.Requests
{
    public class PaymentFrequentSelectRequest
    {
        public short? Payment_Freq_CD { get; set; }
        public string? Short_Desc { get; set; }
        public int? Disp_Seq { get; set; }
        public DateTime? Eff_Date { get; set; }
        public DateTime? Exp_Date { get; set; }
    }
}
