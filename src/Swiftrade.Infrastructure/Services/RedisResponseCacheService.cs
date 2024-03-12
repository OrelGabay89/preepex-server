namespace Swiftrade.Infrastructure.Services
{
    using StackExchange.Redis;
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Swiftrade.Core.Application.Interfaces; 

    public class RedisResponseCacheService : IResponseCacheService
    {
        private readonly IDatabase _database;
        private readonly IConnectionMultiplexer _redisConnection;

        public RedisResponseCacheService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
            _redisConnection = redis;
        }

        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive)
        {
            if (response == null || !IsRedisConnected())
            {
                return;
            }

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var serializedResponse = JsonSerializer.Serialize(response, options);
                await _database.StringSetAsync(cacheKey, serializedResponse, timeToLive);
            }
            catch (Exception ex)
            {
                // Handle or log the exception as necessary
                Console.WriteLine($"Error caching data in Redis: {ex.Message}");
            }
        }

        public async Task<string> GetCachedResponseAsync(string cacheKey)
        {
            if (!IsRedisConnected())
            {
                return null;
            }

            try
            {
                var cachedResponse = await _database.StringGetAsync(cacheKey);

                return cachedResponse.IsNullOrEmpty ? null : cachedResponse.ToString();
            }
            catch (Exception ex)
            {
                // Handle or log the exception as necessary
                Console.WriteLine($"Error retrieving data from Redis: {ex.Message}");
                return null;
            }
        }

        private bool IsRedisConnected()
        {
            return _redisConnection != null && _redisConnection.IsConnected;
        }
    }

}