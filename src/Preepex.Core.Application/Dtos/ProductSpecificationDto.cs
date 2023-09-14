using Preepex.Core.Application.Models;
using System.Collections.Generic;

namespace Preepex.Core.Application.Dtos
{
    public class ProductSpecificationDto
    {
        #region Properties

        /// <summary>
        /// Gets or sets the grouped specification attribute models
        /// </summary>
        public IList<ProductSpecificationAttributeGroupModel> Groups { get; set; }

        #endregion

        #region Ctor

        public ProductSpecificationDto()
        {
            Groups = new List<ProductSpecificationAttributeGroupModel>();
        }

        #endregion
    }
}
