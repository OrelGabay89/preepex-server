using Preepex.Core.Domain.Entities;
using Preepex.Core.Domain.Entities.ApplicationEntities;
using Preepex.Core.Domain.Enumerations;
using Preepex.Core.Domain.NopEntities;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Preepex.Core.Application.Interfaces.Shared.Catalog
{
    public interface IProductService
    {
        IGenericRepository<Domain.Entities.Product> ProductRepository { get; }
        Task<IPagedList<Productreview>> GetAllProductReviewsAsync(int customerId = 0, bool? approved = null, DateTime? fromUtc = null, DateTime? toUtc = null, string message = null, int storeId = 0, int productId = 0, int vendorId = 0, bool showHidden = false, int pageIndex = 0, int pageSize = int.MaxValue);
        Task<IList<Domain.Entities.Product>> GetAssociatedProductsAsync(int parentGroupedProductId, int storeId = 0, int vendorId = 0, bool showHidden = false);
        Task<IList<Domain.Entities.Product>> GetManufacturerFeaturedProductsAsync(int manufacturerId, int storeId = 0);
        Task<int> GetNumberOfProductsInCategoryAsync(IList<int> categoryIds = null, int storeId = 0);
        Task<IReadOnlyList<ProductBrand>> GetProductBrands();
        Task<Domain.Entities.Product> GetProductByIdAsync(int productId);
        Task<IList<Relatedproduct>> GetRelatedProductsByProductIdAsync(int productId, bool showHidden = false);
        Task<int> GetTotalStockQuantityAsync(Domain.Entities.Product product, bool useReservedQuantity = true, int warehouseId = 0);

        Task<IList<Domain.Entities.Product>> NewProducts(int storeId = 0);
        Task<IList<Domain.Entities.Product>> OnSaleProducts(int storeId = 0);
        Task<IPagedList<Domain.Entities.Product>> SearchProductsAsync(
                int pageIndex = 0,
                int pageSize = int.MaxValue,
                IList<int> categoryIds = null,
                IList<int> manufacturerIds = null,
                int storeId = 0,
                int vendorId = 0,
                int warehouseId = 0,
                ProductType? productType = null,
                bool visibleIndividuallyOnly = false,
                bool excludeFeaturedProducts = false,
                decimal? priceMin = null,
                decimal? priceMax = null,
                int productTagId = 0,
                string keywords = null,
                bool searchDescriptions = false,
                bool searchManufacturerPartNumber = true,
                bool searchSku = true,
                bool searchProductTags = false,
                int languageId = 0,
                IList<Specificationattributeoption> filteredSpecOptions = null,
                ProductSortingEnum orderBy = ProductSortingEnum.Position,
                bool showHidden = false,
                bool? overridePublished = null);

        /// <summary>
        /// Formats the stock availability/quantity message
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="attributesXml">Selected product attributes in XML format (if specified)</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock message
        /// </returns>
        Task<IList<Domain.Entities.Product>> SpecialProducts(int storeId = 0);
        Task<IList<Domain.Entities.Product>> TopCollections(int storeId = 0);

        /// <summary>
        /// Gets featured products by a category identifier
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the list of featured products
        /// </returns>
        Task<IList<Domain.Entities.Product>> GetCategoryFeaturedProductsAsync(int categoryId, int storeId = 0);
    }
}
