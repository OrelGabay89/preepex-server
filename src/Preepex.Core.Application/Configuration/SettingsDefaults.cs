

using Preepex.Core.Application.Caching;

namespace Preepex.Core.Application.Configuration
{
    public static partial class SettingsDefaults
    {
        public static CacheKey SettingsAllAsDictionaryCacheKey => new("Preepex.setting.all.dictionary.", EntityCacheDefaults<Setting>.Prefix);

    }
}
