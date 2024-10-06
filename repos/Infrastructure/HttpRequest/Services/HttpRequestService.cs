using IdentityModel.Client;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace Infrastructure.HttpRequest
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly ILogger<HttpRequestService> _logger;
        private readonly HttpClient _httpClient;

        public HttpRequestService(ILogger<HttpRequestService> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestInput input)
        {
            var requestResponse = new HttpResponseMessage();

            if (string.IsNullOrWhiteSpace(input.URL) && input.Uri == null)
            {
                throw new HttpRequestException("Url cannot be null");
            }

            try
            {
                var uri = !string.IsNullOrWhiteSpace(input.URL) ? new Uri(input.URL) : input.Uri;
                if (!string.IsNullOrWhiteSpace(input.Token))
                {
                    _httpClient.SetBearerToken(input.Token);
                }

                switch (input.Method)
                {
                    case "Post":
                        requestResponse = await _httpClient.PostAsync(uri, null);
                        break;
                    case "Put":
                        requestResponse = await _httpClient.PutAsync(uri, null);
                        break;
                    case "Delete":
                        requestResponse = await _httpClient.DeleteAsync(uri);
                        break;
                    case "Get":
                    default:
                        requestResponse = await _httpClient.GetAsync(uri);
                        break;
                }

                return requestResponse;
            }
            catch (HttpRequestException hrEx)
            {
                _logger.LogError(hrEx, $"SendHttpRequest{input}");
                throw new Exception(hrEx.Message);
            }
        }

        public async Task<HttpResponseMessage> SendAsync<TEntity>(HttpRequestInput<TEntity> input)
        {
            try
            {
                var uri = !string.IsNullOrWhiteSpace(input.URL) ? new Uri(input.URL) : input.Uri;
                if (!string.IsNullOrWhiteSpace(input.Token))
                {
                    _httpClient.SetBearerToken(input.Token);
                }

                var headerInputs = "";
                var byteContentInputs = new ByteArrayContent(new byte[] { 1 });
                var requestResponse = new HttpResponseMessage();
                if (input.Method == "Get" || input.Method == "Delete")
                {
                    headerInputs = ToQueryString(input.Entity);
                }
                else
                {
                    var jsonInputs = JsonConvert.SerializeObject(input.Entity);
                    var bufferInputs = Encoding.UTF8.GetBytes(jsonInputs);
                    byteContentInputs = new ByteArrayContent(bufferInputs);
                    byteContentInputs.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                }

                switch (input.Method)
                {
                    case "Post":
                        requestResponse = await _httpClient.PostAsync(uri, byteContentInputs);
                        break;
                    case "Put":
                        requestResponse = await _httpClient.PutAsync(uri, byteContentInputs);
                        break;
                    case "Delete":
                        requestResponse = await _httpClient.DeleteAsync(uri + headerInputs);
                        break;
                    case "Get":
                    default:
                        requestResponse = await _httpClient.GetAsync(uri + headerInputs);
                        break;
                }

                return requestResponse;
            }
            catch (HttpRequestException hrEx)
            {
                _logger.LogError(hrEx, $"SendHttpRequest{input}");
                throw new Exception(hrEx.Message);
            }
        }

        private IEnumerable<string> ToQueryStringItem<TEntity>(TEntity entity)
        {
            foreach (var pi in typeof(TEntity).GetProperties())
                yield return $"{pi.Name}={pi.GetValue(entity)}";
        }

        private string ToQueryString<T>(T entity) => $"?{string.Join("&", ToQueryStringItem(entity).ToList())}";
    }
}
