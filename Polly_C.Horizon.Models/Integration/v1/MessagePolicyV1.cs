using Polly_C.Horizon.Models.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.Integration.v1
{
    public class MessagePolicyV1 : Message
    {
        [JsonProperty(Required = Required.Always)]
        public PolicyV1 Policy { get; set; }
    }
}
