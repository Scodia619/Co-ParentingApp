namespace Co_ParentingApp.Application.Redis
{
    public interface IRedisService
    {
        Task SetAsync<T>(string key, T value, TimeSpan? expiry);
        Task<T?> GetAsync<T>(string key);
    }
}
