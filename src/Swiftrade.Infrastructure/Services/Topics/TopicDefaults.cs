
using Swiftrade.Core.Application.Caching;
using Swiftrade.Core.Domain.Entities;

namespace Swiftrade.Infrastructure.Services.Topics
{
    public static partial class TopicDefaults
    {
        #region Caching defaults

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : store ID
        /// {1} : show hidden?
        /// {2} : include in top menu?
        /// </remarks>
        public static CacheKey TopicsAllCacheKey => new("Nop.topic.all.{0}-{1}-{2}", EntityCacheDefaults<Topic>.AllPrefix);

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : store ID
        /// {1} : show hidden?
        /// {2} : include in top menu?
        /// {3} : customer role IDs hash
        /// </remarks>
        public static CacheKey TopicsAllWithACLCacheKey => new("Swiftrade.topic.all.withacl.{0}-{1}-{2}-{3}", EntityCacheDefaults<Topic>.AllPrefix);

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : topic system name
        /// {1} : store id
        /// {2} : customer roles Ids hash
        /// </remarks>
        public static CacheKey TopicBySystemNameCacheKey => new("Swiftrade.topic.bysystemname.{0}-{1}-{2}", TopicBySystemNamePrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        /// <remarks>
        /// {0} : topic system name
        /// </remarks>
        public static string TopicBySystemNamePrefix => "Swiftrade.topic.bysystemname.{0}";

        #endregion
    }

}
