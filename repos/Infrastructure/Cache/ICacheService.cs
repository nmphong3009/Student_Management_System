namespace Infrastructure
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, TimeSpan? expirationTime = null);
        Task DeleteAsync(string key);
        Task DeleteAsync(List<string> keys);
    }
}
