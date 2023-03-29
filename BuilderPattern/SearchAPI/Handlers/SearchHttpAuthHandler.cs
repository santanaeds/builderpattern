using System.Net.Http.Headers;
using static SearchAPI.Models.Constants;

namespace SearchAPI.Handlers
{
    public class SearchHttpAuthHandler : HttpClientHandler
    {
        private readonly ILogger<SearchHttpAuthHandler> _logger;
        private readonly IConfiguration _config;
        private readonly string _apiKey;

        public SearchHttpAuthHandler(
            ILogger<SearchHttpAuthHandler> logger,
            IConfiguration config)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _apiKey =  ConfigKeys.SearchQueryApiKey;

            if (string.IsNullOrWhiteSpace(_apiKey)) throw new ArgumentException("Value cannot be null, whitespace or empty.", nameof(_apiKey));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            try
            {
                request.Headers.Host = request.RequestUri.Host;
                request.Headers.Add("api-key", _apiKey);

                if (request.Content != null)
                {
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    request.Content.Headers.ContentLength = request.Content.ReadAsStringAsync(cancellationToken).GetAwaiter().GetResult().Length;
                }

                return await base.SendAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing HTTP request.");
                throw;
            }
        }
    }
}
