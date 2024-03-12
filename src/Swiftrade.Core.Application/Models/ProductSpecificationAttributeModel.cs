using System.Collections.Generic;

namespace Swiftrade.Core.Application.Models
{
    public record ProductSpecificationAttributeModel : BaseNopEntityModel
    {
        public ProductSpecificationAttributeModel()
        {
            Values = new List<ProductSpecificationAttributeValueModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ProductSpecificationAttributeValueModel> Values { get; set; }
    }
}
