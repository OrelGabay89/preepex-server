using System.Collections.Generic;

namespace Preepex.Core.Application.Models
{
    public class ProductSpecificationModel
    {
        public ProductSpecificationModel()
        {
            Groups = new List<ProductSpecificationAttributeGroupModel>();
        }
        public IList<ProductSpecificationAttributeGroupModel> Groups { get; set; }
    }
}
