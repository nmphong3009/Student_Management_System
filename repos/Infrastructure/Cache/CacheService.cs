using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure
{
    public class CacheService : ICacheService
    {
        private readonly ILogger<CacheService> _logger;
        private readonly IDistributedCache _cache;

        public CacheService(ILogger<CacheService> logger, IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public async Task DeleteAsync(string key)
        {
            try
            {
                await _cache.RemoveAsync(key);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message + " " + ex.StackTrace);
            }
        }

        public async Task DeleteAsync(List<string> keys)
        {
            try
            {
                foreach (var x in keys)
                {
                    await DeleteAsync(x);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message + " " + ex.StackTrace);
            }
        }

        public async Task<T> GetAsync<T>(string key)
        {
            try
            {
                var result = await _cache.GetStringAsync(key);
                if (!string.IsNullOrEmpty(result))
                {
                    return JsonConvert.DeserializeObject<T>(result);
                }
                return default(T);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetAsync = " + key);
                _logger.LogError(ex, ex.Message + " " + ex.StackTrace);

                return default(T);
            }
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expirationTime = null)
        {
            try
            {
                await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value), new DistributedCacheEntryOptions() { SlidingExpiration = expirationTime });
            }
            catch (Exception ex)
            {
                _logger.LogError("SetAsync key= " + key);
                _logger.LogError("SetAsync value = " + JsonConvert.SerializeObject(value));
                _logger.LogError(ex, ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
