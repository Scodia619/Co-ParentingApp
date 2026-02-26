using Co_ParentingApp.Application.Redis;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

public class RedisService(IDistributedCache cache) : IRedisService
{
    private readonly IDistributedCache _cache = cache;

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiry)
    {
        var bytes = JsonSerializer.SerializeToUtf8Bytes(value);

        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiry
        };

        await _cache.SetAsync(key, bytes, options).ConfigureAwait(false);
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var bytes = await _cache.GetAsync(key).ConfigureAwait(false);

        return bytes is null ? default : JsonSerializer.Deserialize<T>(bytes);
    }
}