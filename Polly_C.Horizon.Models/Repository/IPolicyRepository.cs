using Polly_C.Horizon.Models.Integration.v1;

namespace Polly_C.Horizon.Models.Policy
{
    public interface IPolicyRepository
    {
       Task<bool> CreateNewPolicyV1(MessagePolicyV1 policyToCreate);
    }
}