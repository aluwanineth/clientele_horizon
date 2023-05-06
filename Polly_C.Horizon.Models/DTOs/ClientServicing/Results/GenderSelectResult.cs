using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.DTOs.ClientServicing.Results
{
    public class GenderSelectResult
    {
        public int Gender_CD { get; set; }
        public string S_Desc { get; set; }
        public short Disp_Seq { get; set; }
        public DateTime Eff_Date { get; set; }
        public DateTime Exp_Date { get; set; }
    }
}
