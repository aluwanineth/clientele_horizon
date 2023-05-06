using Polly_C.Horizon.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.Integration
{
    public class Message
    {       
        [JsonProperty(Required = Required.Always)]
        public Guid MessageId { get; set; }
        [JsonProperty(Required = Required.Always)]
        public DateTime MessageDateTime { get; set; }
    }
}
