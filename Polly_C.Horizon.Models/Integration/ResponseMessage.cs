using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.Integration
{
    public class ResponseMessage
    {
        public Guid? CorrelationId { get; set; } = null;
        public string Message { get; set; } = string.Empty;
    }
}
