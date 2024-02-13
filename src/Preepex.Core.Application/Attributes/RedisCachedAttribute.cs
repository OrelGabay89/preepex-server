using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Preepex.Core.Application.Caching;
using Preepex.Core.Application.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preepex.Core.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RedisCachedAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLiveSeconds;
        public RedisCachedAttribute(int timeToLiveSeconds)
        {
            _timeToLiveSeconds = timeToLiveSeconds;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            #if DEBUG
            // always resolve the next because we don't want to cache the response during development
            await next();
            #endif

            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();
            var staticCacheManager = context.HttpContext.RequestServices.GetRequiredService<IStaticCacheManager>();
            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);

            string cachedResponse = null;
            bool isRedisAvailable = true;

            try
            {
                cachedResponse = await cacheService.GetCachedResponseAsync(cacheKey);
            }
            catch (Exception) // Redis not available
            {
                isRedisAvailable = false;
                var inMemoryCacheKey = staticCacheManager.PrepareKeyForDefaultCache(PreepexModelCacheDefaults.RequestCacheKey, cacheKey);
                cachedResponse = await staticCacheManager.GetAsync(inMemoryCacheKey, () => Task.FromResult(string.Empty));
            }

            if (!string.IsNullOrEmpty(cachedResponse))
            {
                var contentResult = new ContentResult
                {
                    Content = cachedResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentResult;
                return;
            }

            var executedContext = await next(); // Move to controller

            if (executedContext.Result is OkObjectResult okObjectResult)
            {
                if (isRedisAvailable)
                {
                    await cacheService.CacheResponseAsync(cacheKey, okObjectResult.Value, TimeSpan.FromSeconds(_timeToLiveSeconds));
                }
                else
                {
                    var inMemoryCacheKey = staticCacheManager.PrepareKeyForDefaultCache(PreepexModelCacheDefaults.RequestCacheKey, cacheKey);
                    // Use GetAsync to cache the data only if it's not already in the in-memory cache
                    await staticCacheManager.GetAsync(inMemoryCacheKey, async () =>
                    {
                        await Task.Delay(0); // This is a placeholder for any async operation you might need
                        return okObjectResult.Value;
                    });
                }
            }
        }

        private static string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();

            string storeIdentifier = request.Headers["Preepex-Store"];

            keyBuilder.Append($"{request.Scheme}://{request.Host.Host}{request.Path}{storeIdentifier}");
            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }
            return keyBuilder.ToString();
        }
    }
}