using Swiftrade.Core.Application.Interfaces;
using Swiftrade.Core.Application.Interfaces.Shared;
using Swiftrade.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Swiftrade.Infrastructure.Services
{
    public class SiteService : ISiteSettings
    {
        private readonly IGenericRepository<SiteSettings> _siteSettingsRepository;

        public SiteService(IGenericRepository<SiteSettings> siteSettingsRepository)
        {
            _siteSettingsRepository = siteSettingsRepository;
        }

        public async Task<SiteSettings> GetSiteSettingsByIdAsync(int id)
        {
            return await _siteSettingsRepository.GetByIdAsync(id);
        }
    }
}