using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swiftrade.Core.Application.Interfaces;
using Swiftrade.Core.Application.Interfaces.Shared;
using Swiftrade.Core.Application.Interfaces.Shared.Catalog;
using System.Threading.Tasks;

namespace Swiftrade.Web.Presentation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteSettingsController : ControllerBase
    {
        private readonly ISiteSettings _siteSettings;
        private readonly IStoreContext _storeContext;

        public SiteSettingsController(ISiteSettings siteSettings)
        {
            _siteSettings = siteSettings;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetSiteSettings()
        {
            var store = await _storeContext.GetCurrentStoreAsync();
            if (store == null)
            {
                return NotFound($"Store with ID {store.Id} not found.");
            }

            // Assuming GetSiteSettingsAsync is a method you've implemented
            // that fetches site settings for a given store.
            var siteSettings = await _siteSettings.GetSiteSettingsByIdAsync(store.Id);
            if (siteSettings == null)
            {
                return NotFound($"Site settings for store ID {store.Id} not found.");
            }

            return Ok(siteSettings);
        }
    }
}
