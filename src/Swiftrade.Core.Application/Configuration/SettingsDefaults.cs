

using Swiftrade.Core.Application.Caching;

namespace Swiftrade.Core.Application.Configuration
{
    public static partial class SettingsDefaults
    {
        public static CacheKey SettingsAllAsDictionaryCacheKey => new("Swiftrade.setting.all.dictionary.", EntityCacheDefaults<Setting>.Prefix);

    }
}
