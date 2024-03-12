using Swiftrade.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Swiftrade.Core.Application.Interfaces.Shared
{
    public interface ISpecificationAttributeService
    {
        /// <summary>
        /// Gets a specification attribute option
        /// </summary>
        /// <param name="specificationAttributeOption">The specification attribute option</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the specification attribute option
        /// </returns>
        Task<Specificationattributeoption> GetSpecificationAttributeOptionByIdAsync(int specificationAttributeOption);

        /// <summary>
        /// Gets a specification attribute
        /// </summary>
        /// <param name="specificationAttributeId">The specification attribute identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the specification attribute
        /// </returns>
        Task<Specificationattribute> GetSpecificationAttributeByIdAsync(int specificationAttributeId);

        /// <summary>
        /// Gets a product specification attribute mapping collection
        /// </summary>
        /// <param name="productId">Product identifier; 0 to load all records</param>
        /// <param name="specificationAttributeOptionId">Specification attribute option identifier; 0 to load all records</param>
        /// <param name="allowFiltering">0 to load attributes with AllowFiltering set to false, 1 to load attributes with AllowFiltering set to true, null to load all attributes</param>
        /// <param name="showOnProductPage">0 to load attributes with ShowOnProductPage set to false, 1 to load attributes with ShowOnProductPage set to true, null to load all attributes</param>
        /// <param name="specificationAttributeGroupId">Specification attribute group identifier; 0 to load all records; null to load attributes without group</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the product specification attribute mapping collection
        /// </returns>
        Task<IList<ProductSpecificationattributeMapping>> GetProductSpecificationAttributesAsync(int productId = 0,
            int specificationAttributeOptionId = 0, bool? allowFiltering = null, bool? showOnProductPage = null, int? specificationAttributeGroupId = 0);

        /// <summary>
        /// Gets product specification attribute groups
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the specification attribute groups
        /// </returns>
        Task<IList<Specificationattributegroup>> GetProductSpecificationAttributeGroupsAsync(int productId);
    }
}
