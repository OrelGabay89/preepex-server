

using Preepex.Core.Application.Caching;
using Preepex.Core.Domain.Entities;

namespace Preepex.Infrastructure
{
    /// <summary>
    /// Represents default values related to directory services
    /// </summary>
    public static partial class PreepexDirectoryDefaults
    {
        #region Caching defaults

        #region Countries

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : Two letter ISO code
        /// </remarks>
        public static CacheKey CountriesByTwoLetterCodeCacheKey => new("Preepex.country.bytwoletter.{0}", EntityCacheDefaults<Country>.Prefix);

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : Two letter ISO code
        /// </remarks>
        public static CacheKey CountriesByThreeLetterCodeCacheKey => new("Preepex.country.bythreeletter.{0}", EntityCacheDefaults<Country>.Prefix);

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// {1} : show hidden records?
        /// {2} : current store ID
        /// </remarks>
        public static CacheKey CountriesAllCacheKey => new("Preepex.country.all.{0}-{1}-{2}", EntityCacheDefaults<Country>.Prefix);

        #endregion

        #region Currencies

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// </remarks>
        public static CacheKey CurrenciesAllCacheKey => new("Preepex.currency.all.{0}", EntityCacheDefaults<Currency>.AllPrefix);

        #endregion

        #region States and provinces

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : country ID
        /// {1} : language ID
        /// {2} : show hidden records?
        /// </remarks>
        public static CacheKey StateProvincesByCountryCacheKey => new("Preepex.stateprovince.bycountry.{0}-{1}-{2}", EntityCacheDefaults<StateProvince>.Prefix);

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// </remarks>
        public static CacheKey StateProvincesAllCacheKey => new("Preepex.stateprovince.all.{0}", EntityCacheDefaults<StateProvince>.Prefix);

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : abbreviation
        /// {1} : country ID
        /// </remarks>
        public static CacheKey StateProvincesByAbbreviationCacheKey => new("Preepex.stateprovince.byabbreviation.{0}-{1}", EntityCacheDefaults<StateProvince>.Prefix);

        #endregion

        #endregion
    }
}
