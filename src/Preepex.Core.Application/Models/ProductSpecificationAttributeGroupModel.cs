using System.Collections.Generic;

namespace Preepex.Core.Application.Models
{
    public record ProductSpecificationAttributeGroupModel : BaseNopEntityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the specification attribute group attributes
        /// </summary>
        public IList<ProductSpecificationAttributeModel> Attributes { get; set; }


        public ProductSpecificationAttributeGroupModel()
        {
            Attributes = new List<ProductSpecificationAttributeModel>();
        }

    }
}
