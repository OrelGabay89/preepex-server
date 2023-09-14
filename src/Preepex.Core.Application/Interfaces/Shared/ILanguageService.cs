using Preepex.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Preepex.Core.Application.Interfaces.Shared
{
    public interface ILanguageService
    {
        /// <summary>
        /// Gets all languages
        /// </summary>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the languages
        /// </returns>
        Task<IList<Language>> GetAllLanguagesAsync(bool showHidden = false, int storeId = 0);
    }
}
