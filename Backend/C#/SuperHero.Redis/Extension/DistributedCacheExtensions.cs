using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace SuperHero.Redis.Extension
{
    public static class DistributedCacheExtensions
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache,
                                                   string guid,
                                                   T data,
                                                   TimeSpan? absoluteExpireTime = null,
                                                   TimeSpan? slidingExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60),
                SlidingExpiration = slidingExpireTime
            };

            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(guid, jsonData, options);
        }

        public static async Task<T?> GetRecordAsync<T>(this IDistributedCache cache,
                                                       string guid)
        {
            string jsonData = default;
            try
            {
                jsonData = await cache.GetStringAsync(guid);

                if (jsonData is null)
                {
                    return default;
                }
            }
            catch (Exception ex)
            {

            }
            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public static async Task PostRecordAsync<T>(this IDistributedCache cache,
                                                        string guid,
                                                        T data)
        {
            TimeSpan? absoluteExpireTime = TimeSpan.FromMinutes(2);
            TimeSpan? slidingExpireTime = null;

            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime;
            options.SlidingExpiration = slidingExpireTime;

            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(guid, jsonData, options);
        }
    }
}
