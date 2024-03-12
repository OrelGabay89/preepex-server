using Swiftrade.Core.Domain.Entities;
using Swiftrade.Core.Domain.Entities.Common;
using Swiftrade.Core.Domain.Interfaces;
using System.Threading.Tasks;
using Swiftrade.Common.Paging;
using System.Collections.Generic;
using System;


namespace Swiftrade.Core.Application.Interfaces.Shared
{
    public interface IUrlRecordService
    {
        Task<string> GetActiveSlugAsync(int entityId, string entityName, int languageId);
        Task<IPagedList<UrlRecord>> GetAllUrlRecordsAsync(string slug = "", int? languageId = null, bool? isActive = null, int pageIndex = 0, int pageSize = int.MaxValue);
        Task<UrlRecord> GetBySlugAsync(string slug);
        Task<string> GetSeNameAsync(int entityId, string entityName, int? languageId = null, bool returnDefaultValue = true, bool ensureTwoPublishedLanguages = true);
        Task<string> GetSeNameAsync(string name, bool convertNonWesternChars, bool allowUnicodeCharsInUrls);
        Task<string> GetSeNameAsync<T>(T entity, int? languageId = null, bool returnDefaultValue = true, bool ensureTwoPublishedLanguages = true) where T : BaseEntity<int>, ISlugSupported;
        Task<Dictionary<Tuple<string, string, int>, string>> GetSeNamesAsync<T>(T[] entity, int? languageId = null, bool returnDefaultValue = true, bool ensureTwoPublishedLanguages = true) where T : BaseEntity<int>, ISlugSupported;    }

}
