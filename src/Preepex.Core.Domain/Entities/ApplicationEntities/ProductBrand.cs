using Preepex.Core.Domain.Entities.Common;

namespace Preepex.Core.Domain.Entities.ApplicationEntities
{
    public class ProductBrand : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}