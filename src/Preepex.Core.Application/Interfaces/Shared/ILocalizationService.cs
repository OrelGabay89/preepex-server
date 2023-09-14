using Microsoft.Extensions.Localization;
using Preepex.Core.Domain.Entities.Common;
using Preepex.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Preepex.Core.Domain.Entities;

namespace Preepex.Core.Application.Interfaces.Shared
{
    public interface ILocalizationService
    {
        LocalizedString this[string key] { get; }
        LocalizedString GetLocalizedString(string key);
        LocalizedString GetCulturedLocalizedString(string key, string culture);
        IEnumerable<LocalizedString> GetAllCulturedLocalizedString();
        string GetLocalizedString(string key, params string[] parameters);

        /// <summary>
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
        Task<TPropType> GetLocalizedAsync<TEntity, TPropType>(TEntity entity, Expression<Func<TEntity, TPropType>> keySelector,
            int? languageId = null, bool returnDefaultValue = true, bool ensureTwoPublishedLanguages = true)
            where TEntity : BaseEntity<int>, ILocalizedEntity;

        /// <summary>
        /// Get localized property of an entity
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="keySelector"></param>
        /// <param name="languageId"></param>
        /// <param name="returnDefaultValue"></param>
        /// <param name="ensureTwoPublishedLanguages"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TPropType"></typeparam>
        /// <returns></returns>
        Task<Dictionary<int, TPropType>> GetLocalizedBatchAsync<TEntity, TPropType>(
            IEnumerable<TEntity> entities,
            Expression<Func<TEntity, TPropType>> keySelector,
            int? languageId = null,
            bool returnDefaultValue = true,
            bool ensureTwoPublishedLanguages = true)
            where TEntity : BaseEntity<int>, ILocalizedEntity;

        /// <summary>
        /// Gets a resource string based on the specified ResourceKey property.
        /// </summary>
        /// <param name="resourceKey">A string representing a ResourceKey.</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a string representing the requested resource string.
        /// </returns>
        Task<string> GetResourceAsync(string resourceKey);

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
        Task<string> GetResourceAsync(string resourceKey, int languageId,
            bool logIfNotFound = true, string defaultValue = "", bool returnEmptyIfNotFound = false);
    }
}