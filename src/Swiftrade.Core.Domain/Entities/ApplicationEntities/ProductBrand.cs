using Swiftrade.Core.Domain.Entities.Common;

namespace Swiftrade.Core.Domain.Entities.ApplicationEntities
{
    public class ProductBrand : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}