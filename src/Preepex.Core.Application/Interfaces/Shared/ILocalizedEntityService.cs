using System.Collections.Generic;
using System.Threading.Tasks;

namespace Preepex.Core.Application.Interfaces.Shared
{
    public interface ILocalizedEntityService
    {
        /// <summary>
        /// Find localized value
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <param name="entityId">Entity identifier</param>
        /// <param name="localeKeyGroup">Locale key group</param>
        /// <param name="localeKey">Locale key</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the found localized value
        /// </returns>
        Task<string> GetLocalizedValueAsync(int languageId, int entityId, string localeKeyGroup, string localeKey);

        Task<Dictionary<int, string>> GetLocalizedValuesBatchAsync(int languageId, List<int> entityIds,
            string localeKeyGroup, string localeKey);
    }
}
