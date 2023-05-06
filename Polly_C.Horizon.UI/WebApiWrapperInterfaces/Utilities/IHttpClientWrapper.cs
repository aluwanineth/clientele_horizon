using Polly_C.Horizon.Models.Enums;

namespace Polly_C.Horizon.UI.WebApiWrapperInterfaces.Utilities
{
    public interface IHttpClientWrapper
    {
        Task<TResponse> postAsync<TResponse, TRequest>(Controllers controller, string resource, TRequest request);

        Task<TResponse> getAsync<TResponse>(Controllers controller, string resource);
    }
}
