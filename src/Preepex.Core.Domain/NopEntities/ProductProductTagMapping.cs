using Preepex.Core.Domain.Entities.Common;

namespace Preepex.Core.Domain.NopEntities
{
    /// <summary>
    /// Represents a product-product tag mapping class
    /// </summary>
    public partial class ProductProducttagMapping : BaseEntity<int>
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product tag identifier
        /// </summary>
        public int ProductTagId { get; set; }

    }
}
