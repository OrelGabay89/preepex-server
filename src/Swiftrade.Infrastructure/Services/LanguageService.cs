using Swiftrade.Core.Application;
using Swiftrade.Core.Application.Caching;
using Swiftrade.Core.Application.Interfaces;
using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Application.Interfaces.Shared;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swiftrade.Infrastructure.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IStoreMappingService _storeMappingService;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IGenericRepository<Language> _languageRepository;
        public LanguageService(IStoreMappingService storeMappingService, IStaticCacheManager staticCacheManager, IGenericRepository<Language> languageRepository)
        {
            _storeMappingService = storeMappingService;
            _staticCacheManager = staticCacheManager;
            _languageRepository = languageRepository;

        }

        /// <summary>
        /// Gets all languages
        /// </summary>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the languages
        /// </returns>
        public virtual async Task<IList<Language>> GetAllLanguagesAsync(bool showHidden = false, int storeId = 0)
        {
            //cacheable copy
            var key = _staticCacheManager.PrepareKeyForDefaultCache(SwiftradeLocalizationDefaults.LanguagesAllCacheKey, storeId, showHidden);

            var languages = await _staticCacheManager.GetAsync(key, async () =>
            {
                var allLanguages = await _languageRepository.GetAllAsync(query =>
                {
                    if (!showHidden)
                        query = query.Where(l => l.Published);
                    query = query.OrderBy(l => l.DisplayOrder).ThenBy(l => l.Id);

                    return query;
                });

                //store mapping
                if (storeId > 0)
                    allLanguages = await allLanguages
                        .WhereAwait(async l => await _storeMappingService.AuthorizeAsync(l, storeId))
                        .ToListAsync();

                return allLanguages;
            });

            return languages;
        }
    }
}
