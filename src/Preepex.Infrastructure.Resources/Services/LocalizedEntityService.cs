using System.Collections.Generic;
using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Application.Interfaces.Shared;
using System.Linq;
using System.Threading.Tasks;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Domain.Entities;

namespace Preepex.Infrastructure.Resources.Services
{
    public class LocalizedEntityService : ILocalizedEntityService
    {
        private readonly IGenericRepository<Localizedproperty> _localizedPropertyRepository;

        public LocalizedEntityService(IGenericRepository<Localizedproperty> localizedPropertyRepository)
        {
            _localizedPropertyRepository = localizedPropertyRepository;
        }
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
        public virtual async Task<string> GetLocalizedValueAsync(int languageId, int entityId, string localeKeyGroup, string localeKey)
        {
            //var key = _staticCacheManager.PrepareKeyForDefaultCache(NopLocalizationDefaults.LocalizedPropertyCacheKey
            //    , languageId, entityId, localeKeyGroup, localeKey);

            //return await _staticCacheManager.GetAsync(key, async () =>
            //{
            //    var source = _localizationSettings.LoadAllLocalizedPropertiesOnStartup
            //        //load all records (we know they are cached)
            //        ? (await GetAllLocalizedPropertiesAsync()).AsQueryable()
            //        //gradual loading
            //        : _localizedPropertyRepository.Table;

            //    var query = from lp in source
            //                where lp.LanguageId == languageId &&
            //                      lp.EntityId == entityId &&
            //                      lp.LocaleKeyGroup == localeKeyGroup &&
            //                      lp.LocaleKey == localeKey
            //                select lp.LocaleValue;

            //    //little hack here. nulls aren't cacheable so set it to ""
            //    var localeValue = query.FirstOrDefault() ?? string.Empty;

            //    return localeValue;
            //});

            var source = _localizedPropertyRepository.Table;

            var query = from lp in source
                        where lp.LanguageId == languageId &&
                              lp.EntityId == entityId &&
                              lp.LocaleKeyGroup == localeKeyGroup &&
                              lp.LocaleKey == localeKey
                        select lp.LocaleValue;

            //little hack here. nulls aren't cacheable so set it to ""
            var localeValue = query.FirstOrDefault() ?? string.Empty;

            return localeValue;
        }
        
        public virtual async Task<Dictionary<int, string>> GetLocalizedValuesBatchAsync(int languageId, List<int> entityIds, string localeKeyGroup, string localeKey)
        {
            var result = new Dictionary<int, string>();

            // Your source would be your database context or repository.

            // Fetch all the records that match the given language, entity IDs, locale key group, and locale key.
            var localizedRecords = _localizedPropertyRepository.Table
                .Where(lp => lp.LanguageId == languageId)
                .Where(lp => entityIds.Contains(lp.EntityId))
                .Where(lp => lp.LocaleKeyGroup == localeKeyGroup)
                .Where(lp => lp.LocaleKey == localeKey)
                .Select(lp => new { lp.EntityId, lp.LocaleValue })
                .ToList();

            // Add the localized values to the dictionary.
            foreach (var record in localizedRecords)
            {
                result[record.EntityId] = record.LocaleValue;
            }

            // For any entity IDs that didn't have a localized value, add them to the dictionary with a value of string.Empty.
            foreach (var id in entityIds)
            {
                result.TryAdd(id, string.Empty);
            }

            return result;
        }


    }
}
