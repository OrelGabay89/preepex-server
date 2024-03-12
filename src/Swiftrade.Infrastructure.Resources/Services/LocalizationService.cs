using Microsoft.Extensions.Localization;
using Swiftrade.Core.Application;
using Swiftrade.Core.Application.Interfaces.Shared;
using Swiftrade.Core.Domain.Entities.Common;
using Swiftrade.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Swiftrade.Infrastructure.Resources.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer _localizer;
        private readonly ILanguageService _languageService;
        private readonly ILocalizedEntityService _localizedEntityService;

        public LocalizationService(IStringLocalizerFactory factory, ILanguageService languageService,
            ILocalizedEntityService localizedEntityService)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            var type = Type.GetType($"PreepexResource_{currentCulture.Name}"); // typeof(PreepexResource_en);
            //var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            //_localizer = factory.Create($"PreepexResource_{currentCulture.Name}", assemblyName.Name);
            _languageService = languageService;
            _localizedEntityService = localizedEntityService;
        }

        public LocalizedString this[string key] => _localizer[key];

        public LocalizedString GetLocalizedString(string key)
        {
            return _localizer[key];
        }

        public LocalizedString GetCulturedLocalizedString(string key, string culture)
        {
            CultureInfo cultureInfo = new CultureInfo(culture);
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
            return GetLocalizedString(key);
        }

        public string GetLocalizedString(string key, params string[] parameters)
        {
            return string.Format(_localizer[key], parameters);
        }

        public IEnumerable<LocalizedString> GetAllCulturedLocalizedString()
        {
            return _localizer.GetAllStrings();
        }


        /// Get localized property of an entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <typeparam name="TPropType">Property type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="keySelector">Key selector</param>
        /// <param name="languageId">Language identifier; pass null to use the current working language; pass 0 to get standard language value</param>
        /// <param name="returnDefaultValue">A value indicating whether to return default value (if localized is not found)</param>
        /// <param name="ensureTwoPublishedLanguages">A value indicating whether to ensure that we have at least two published languages; otherwise, load only default value</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the localized property
        /// </returns>
        public virtual async Task<TPropType> GetLocalizedAsync<TEntity, TPropType>(TEntity entity,
            Expression<Func<TEntity, TPropType>> keySelector,
            int? languageId = null, bool returnDefaultValue = true, bool ensureTwoPublishedLanguages = true)
            where TEntity : BaseEntity<int>, ILocalizedEntity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (keySelector.Body is not MemberExpression member)
                throw new ArgumentException($"Expression '{keySelector}' refers to a method, not a property.");

            if (member.Member is not PropertyInfo propInfo)
                throw new ArgumentException($"Expression '{keySelector}' refers to a field, not a property.");

            var result = default(TPropType);
            var resultStr = string.Empty;

            var localeKeyGroup = entity.GetType().Name;
            var localeKey = propInfo.Name;

            //var workingLanguage = await _workContext.GetWorkingLanguageAsync();

            //if (!languageId.HasValue)
            //    languageId = workingLanguage?.Id;

            if (languageId > 0)
            {
                //ensure that we have at least two published languages
                var loadLocalizedValue = true;
                if (ensureTwoPublishedLanguages)
                {
                    var totalPublishedLanguages = (await _languageService.GetAllLanguagesAsync()).Count;
                    loadLocalizedValue = totalPublishedLanguages >= 2;
                }

                //localized value
                if (loadLocalizedValue)
                {
                    resultStr = await _localizedEntityService
                        .GetLocalizedValueAsync(languageId.Value, entity.Id, localeKeyGroup, localeKey);
                    if (!string.IsNullOrEmpty(resultStr))
                        result = CommonHelper.To<TPropType>(resultStr);
                }
            }

            //set default value if required
            if (!string.IsNullOrEmpty(resultStr) || !returnDefaultValue)
                return result;
            var localizer = keySelector.Compile();
            result = localizer(entity);

            return result;
        }


        public virtual async Task<Dictionary<int, TPropType>> GetLocalizedBatchAsync<TEntity, TPropType>(
            IEnumerable<TEntity> entities,
            Expression<Func<TEntity, TPropType>> keySelector,
            int? languageId = null,
            bool returnDefaultValue = true,
            bool ensureTwoPublishedLanguages = true)
            where TEntity : BaseEntity<int>, ILocalizedEntity
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            if (keySelector.Body is not MemberExpression member)
                throw new ArgumentException($"Expression '{keySelector}' refers to a method, not a property.");

            if (member.Member is not PropertyInfo propInfo)
                throw new ArgumentException($"Expression '{keySelector}' refers to a field, not a property.");

            var result = new Dictionary<int, TPropType>();
            var localeKeyGroup = typeof(TEntity).Name;
            var localeKey = propInfo.Name;

            // Determine if we should load localized values
            var loadLocalizedValue = true;
            if (ensureTwoPublishedLanguages)
            {
                var totalPublishedLanguages = (await _languageService.GetAllLanguagesAsync()).Count;
                loadLocalizedValue = totalPublishedLanguages >= 2;
            }

            if (languageId > 0 && loadLocalizedValue)
            {
                // TODO: Implement a batch version of GetLocalizedValuesAsync that fetches localized values for multiple entities.
                var localizedEntities = entities.ToList();
                
                var localizedValues = await _localizedEntityService.GetLocalizedValuesBatchAsync(languageId.Value, localizedEntities.Select(e => e.Id).ToList(), localeKeyGroup, localeKey);

                foreach (var entity in localizedEntities)
                {
                    if (localizedValues.TryGetValue(entity.Id, out var localizedValue) &&
                        !string.IsNullOrEmpty(localizedValue))
                    {
                        result[entity.Id] = CommonHelper.To<TPropType>(localizedValue);
                    }
                    else if (returnDefaultValue)
                    {
                        var localizer = keySelector.Compile();
                        result[entity.Id] = localizer(entity);
                    }
                }
            }
            else
            {
                // If not loading localized values, just return the default values.
                var localizer = keySelector.Compile();
                foreach (var entity in entities)
                {
                    result[entity.Id] = localizer(entity);
                }
            }

            return result;
        }


        /// <summary>
        /// Gets a resource string based on the specified ResourceKey property.
        /// </summary>
        /// <param name="resourceKey">A string representing a ResourceKey.</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a string representing the requested resource string.
        /// </returns>
        public virtual async Task<string> GetResourceAsync(string resourceKey)
        {
            //var workingLanguage = await _workContext.GetWorkingLanguageAsync();

            //if (workingLanguage != null)
            //    return await GetResourceAsync(resourceKey, workingLanguage.Id);

            return string.Empty;
        }

        /// <summary>
        /// Gets a resource string based on the specified ResourceKey property.
        /// </summary>
        /// <param name="resourceKey">A string representing a ResourceKey.</param>
        /// <param name="languageId">Language identifier</param>
        /// <param name="logIfNotFound">A value indicating whether to log error if locale string resource is not found</param>
        /// <param name="defaultValue">Default value</param>
        /// <param name="returnEmptyIfNotFound">A value indicating whether an empty string will be returned if a resource is not found and default value is set to empty string</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a string representing the requested resource string.
        /// </returns>
        public virtual async Task<string> GetResourceAsync(string resourceKey, int languageId,
            bool logIfNotFound = true, string defaultValue = "", bool returnEmptyIfNotFound = false)
        {
            var result = string.Empty;
            if (resourceKey == null)
                resourceKey = string.Empty;
            resourceKey = resourceKey.Trim().ToLowerInvariant();

            if (!string.IsNullOrEmpty(result))
                return result;

            if (!string.IsNullOrEmpty(defaultValue))
            {
                result = defaultValue;
            }
            else
            {
                if (!returnEmptyIfNotFound)
                    result = resourceKey;
            }

            return result;
        }
    }
}