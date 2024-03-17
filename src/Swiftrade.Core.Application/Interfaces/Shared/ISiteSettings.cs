using Swiftrade.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Swiftrade.Core.Application.Interfaces.Shared
{
    public interface ISiteSettings
    {
        Task<SiteSettings> GetSiteSettingsByIdAsync(int id);
    }
}