using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.DTOs
{
    public class APISetting
    {
        public string? AuthUrl { get; set; }
        public string? PolicyDetailBaseUrl { get; set; }
        public string? PolicySearchBaseUrl { get; set; }
    }
}
