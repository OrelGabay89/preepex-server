using Swiftrade.Core.Domain.Entities.Common;


namespace Swiftrade.Core.Domain.Entities
{
    public class SiteSettings : BaseEntity<int>
    {
        public string SiteSetting { get; set; }
    }
}
