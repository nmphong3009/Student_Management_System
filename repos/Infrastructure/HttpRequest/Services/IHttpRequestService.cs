namespace Infrastructure.HttpRequest
{
    public interface IHttpRequestService
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestInput input);

        Task<HttpResponseMessage> SendAsync<TEntity>(HttpRequestInput<TEntity> input);
    }
}
