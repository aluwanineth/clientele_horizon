

using Polly_C.Horizon.Data.Customer.Models;

namespace Polly_C.Horizon.Models.DTOs.Wrappers
{
    public class DataRequestWrapper
    {
        public OutputParameter<int> ReturnValue { get; set; } = null;

        public CancellationToken CancellationToken { get; set; } = default;
    }
}
