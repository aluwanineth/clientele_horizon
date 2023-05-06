using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Models.Enums.v1
{
    public enum SmokerV1
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "")]
        NotSet = 0,
        NonSmoker = 1,
        Smoker = 2
    }
}
