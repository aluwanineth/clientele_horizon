using Polly_C.Horizon.Models.Enums;
using Polly_C.Horizon.UI.WebApiWrapperInterfaces.Utilities;
using System.Text;
using System.Text.Json;

namespace Polly_C.Horizon.UI.Wrappers.Utilities
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _client;
        private readonly Dictionary<Controllers, string> _controllerMappings;
        private readonly ILogger<HttpClientWrapper> _logger;

        public HttpClientWrapper(HttpClient client, IConfiguration configuration, ILogger<HttpClientWrapper> logger)
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _client = client;
            _controllerMappings = configuration.GetSection("ControllerMappings").Get<Dictionary<Controllers, string>>();
            _logger = logger;
        }

        public async Task<TResponse> postAsync<TResponse, TRequest>(Controllers controller, string resource, TRequest request)
        {
            try
            {
                var content = JsonSerializer.Serialize(request);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
                string controllerLookup;
                if(!_controllerMappings.TryGetValue(controller, out controllerLookup))
                {
                    throw new Exception($"Controller {controller} not found in configuration");
                }
                var response = await _client.PostAsync(controllerLookup + resource, bodyContent);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<TResponse>(responseContent, _options);
                if (!response.IsSuccessStatusCode || result == null)
                {
                    throw new Exception($"HttpRequestException {response.ReasonPhrase} : {response.ReasonPhrase}");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in HttpRequestWrapper");
                throw new Exception(ex.Message);
            }
        }

        public async Task<TResponse> getAsync<TResponse>(Controllers controller, string resource)
        {
            try
            {
                string controllerLookup;
                if (!_controllerMappings.TryGetValue(controller, out controllerLookup))
                {
                    throw new Exception($"Controller {controller} not found in configuration");
                }
                var urlString = $"{controllerLookup}{resource}";
                var response = await _client.GetAsync(urlString);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<TResponse>(responseContent, _options);
                if (!response.IsSuccessStatusCode || result == null)
                {
                    throw new Exception($"HttpRequestException {response.ReasonPhrase} : {response.ReasonPhrase}");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in HttpRequestWrapper");
                throw new Exception(ex.Message);
            }
        }
    }
}
