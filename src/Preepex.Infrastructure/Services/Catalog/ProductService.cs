using LinqToDB;
using Preepex.Common.Extensions;
using Preepex.Core.Application.Caching;
using Preepex.Core.Application.Extenstions;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Security;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Application.Interfaces.Shared.Catalog;
using Preepex.Core.Application.Interfaces.Shared.Customers;
using Preepex.Core.Domain.Entities;
using Preepex.Core.Domain.Entities.ApplicationEntities;
using Preepex.Core.Domain.Entities.Catalog;
using Preepex.Core.Domain.Enumerations;
using Preepex.Core.Domain.NopEntities;
using Preepex.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Services.Catalog
{
    public class ProductService : IProductService
    {
        public IGenericRepository<Core.Domain.Entities.Product> ProductRepository
        {
            get { return _productRepository; }
        }

        private readonly IGenericRepository<Core.Domain.Entities.Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
        private readonly IGenericRepository<ProductTag> _productTagRepository;
        private readonly IGenericRepository<Productwarehouseinventory> _productWarehouseInventoryRepository;
        private readonly IGenericRepository<ProductManufacturerMapping> _productManufacturerRepository;
        private readonly IGenericRepository<Relatedproduct> _relatedProductRepository;
        private readonly IGenericRepository<Productreview> _productReviewRepository;
        private readonly IGenericRepository<ProductAttributeCombination> _productAttributeCombinationRepository;
        private readonly IGenericRepository<ProductSpecificationattributeMapping> _productSpecificationAttributeRepository;
        private readonly IGenericRepository<ProductProducttagMapping> _productTagMappingRepository;

        private readonly IGenericRepository<Localizedproperty> _localizedPropertyRepository;
        private readonly CatalogSettings _catalogSettings;

        protected readonly ILocalizationService _localizationService;
        private readonly ILanguageService _languageService;
        private readonly ICustomerService _customerService;
        private readonly IAclService _aclService;
        private readonly IStoreMappingService _storeMappingService;

        private readonly IWorkContext _workContext;

        private readonly IStaticCacheManager _staticCacheManager;

        public ProductService(
            IGenericRepository<Core.Domain.Entities.Product> productRepository, 
            IGenericRepository<ProductBrand> productBrandRepository,
            IGenericRepository<Relatedproduct> relatedProductRepository,
            IGenericRepository<Productreview> productReviewRepository, 
            IGenericRepository<ProductManufacturerMapping> productManufacturerRepository,
            IGenericRepository<ProductAttributeCombination> productAttributeCombinationRepository,
            IGenericRepository<ProductSpecificationattributeMapping> productSpecificationAttributeRepository,
            IGenericRepository<Localizedproperty> localizedPropertyRepository,
            IGenericRepository<ProductProducttagMapping> productTagMappingRepository,
            ILanguageService languageService, 
            IStoreMappingService storeMappingService,
            IAclService aclService,
            ILocalizationService localizationService,
            IStaticCacheManager staticCacheManager, 
            IWorkContext workContext,
            CatalogSettings catalogSettings
            )
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productReviewRepository = productReviewRepository;
            _relatedProductRepository = relatedProductRepository;
            _productManufacturerRepository = productManufacturerRepository;
            _productTagMappingRepository = productTagMappingRepository;
            _productAttributeCombinationRepository = productAttributeCombinationRepository;
            _productSpecificationAttributeRepository = productSpecificationAttributeRepository;
            _languageService = languageService;
            _storeMappingService = storeMappingService;
            _localizedPropertyRepository = localizedPropertyRepository;
            _localizationService = localizationService;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
            _catalogSettings = catalogSettings;
            _aclService = aclService;
        }
        /// <summary>
        /// Gets product
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the product
        /// </returns>
        public virtual async Task<Core.Domain.Entities.Product> GetProductByIdAsync(int productId)
        {
            return await _productRepository.GetByIdAsync(productId, cache => default);
        }

        /// <summary>
        /// Gets associated products
        /// </summary>
        /// <param name="parentGroupedProductId">Parent product identifier (used with grouped products)</param>
        /// <param name="storeId">Store identifier; 0 to load all records</param>
        /// <param name="vendorId">Vendor identifier; 0 to load all records</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the products
        /// </returns>
        public virtual async Task<IList<Core.Domain.Entities.Product>> GetAssociatedProductsAsync(int parentGroupedProductId,
            int storeId = 0, int vendorId = 0, bool showHidden = false)
        {
            var query = _productRepository.Table;
            query = query.Where(x => x.ParentGroupedProductId == parentGroupedProductId);
            if (!showHidden)
            {
                query = query.Where(x => x.Published);

                //available dates
                query = query.Where(p =>
                    (!p.AvailableStartDateTimeUtc.HasValue || p.AvailableStartDateTimeUtc.Value < DateTime.UtcNow) &&
                    (!p.AvailableEndDateTimeUtc.HasValue || p.AvailableEndDateTimeUtc.Value > DateTime.UtcNow));
            }
            //vendor filtering
            if (vendorId > 0)
            {
                query = query.Where(p => p.VendorId == vendorId);
            }

            query = query.Where(x => !x.Deleted);
            query = query.OrderBy(x => x.DisplayOrder).ThenBy(x => x.Id);

            var products = await query.ToListAsync();

            //ACL mapping
            if (!showHidden)
                products = await products.WhereAwait(async x => await _aclService.AuthorizeAsync(x)).ToListAsync();

            //Store mapping
            if (!showHidden && storeId > 0)
                products = await products.WhereAwait(async x => await _storeMappingService.AuthorizeAsync(x, storeId)).ToListAsync();

            return products;
        }

        public virtual async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            return await _productBrandRepository.ListAllAsync();
        }


        public virtual async Task<IList<Core.Domain.Entities.Product>> TopCollections(int storeId = 0)
        {
            var query = _productRepository.Table
                .Where(p => p.Published && !p.Deleted)
                .OrderBy(p => p.DisplayOrder)
                .ThenBy(p => p.Id);
            
            var result = await _storeMappingService.ApplyStoreMapping(query, storeId);
            return result.ToList();
        }

        public virtual async Task<IList<Core.Domain.Entities.Product>> OnSaleProducts(int storeId = 0)
        {
            var query = from p in _productRepository.Table
                        orderby p.DisplayOrder, p.Id
                        where p.Published &&
                              !p.Deleted &&
                              p.HasDiscountsApplied
                        select p;

            var result = await _storeMappingService.ApplyStoreMapping(query, storeId);
            return result.ToList();
        }

        public virtual async Task<IList<Core.Domain.Entities.Product>> SpecialProducts(int storeId = 0)
        {
            var query = from p in _productRepository.Table
                        orderby p.DisplayOrder, p.Id
                        where p.Published &&
                              !p.Deleted &&
                              p.ShowOnHomepage
                        select p;


            var result = await _storeMappingService.ApplyStoreMapping(query, storeId);
            return result.ToList();
        }

        public virtual async Task<IList<Core.Domain.Entities.Product>> NewProducts(int storeId = 0)
        {
            var query = _productRepository.Table
                .Where(p => p.Published && !p.Deleted && p.MarkAsNew)
                .OrderBy(p => p.DisplayOrder)
                .ThenBy(p => p.Id)
                .Take(5);


            var result = await _storeMappingService.ApplyStoreMapping(query, storeId);
            return result.ToList();
        }


        /// <summary>
        /// Gets related products by product identifier
        /// </summary>
        /// <param name="productId">The first product identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the related products
        /// </returns>
        public virtual async Task<IList<Relatedproduct>> GetRelatedProductsByProductIdAsync(int productId, bool showHidden = false)
        {
            var query = from rp in _relatedProductRepository.Table
                        join p in _productRepository.Table on rp.ProductId2 equals p.Id
                        where rp.ProductId1 == productId &&
                        !p.Deleted &&
                        (showHidden || p.Published)
                        orderby rp.DisplayOrder, rp.Id
                        select rp;

            var relatedProducts = await _staticCacheManager.GetAsync(_staticCacheManager.PrepareKeyForDefaultCache(PreepexCatalogDefaults.RelatedProductsCacheKey,
                productId, showHidden), async () => await query.ToListAsync());

            return relatedProducts;
        }

        public virtual async Task<IPagedList<Core.Domain.Entities.Product>> SearchProductsAsync(
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
           bool? overridePublished = null)
        {
            //some databases don't support int.MaxValue
            if (pageSize == int.MaxValue)
                pageSize = int.MaxValue - 1;

            var productsQuery = _productRepository.Table;

            if (!showHidden)
                productsQuery = productsQuery.Where(p => p.Published);
            else if (overridePublished.HasValue)
                productsQuery = productsQuery.Where(p => p.Published == overridePublished.Value);

            //apply store mapping constraints
            productsQuery = await _storeMappingService.ApplyStoreMapping(productsQuery, storeId);

            //apply ACL constraints
            if (!showHidden)
            {
                var customer = await _workContext.GetCurrentCustomerAsync();
                productsQuery = await _aclService.ApplyAcl(productsQuery, customer);
            }

            productsQuery = productsQuery
                .Where(p =>
                    !p.Deleted &&
                    (!visibleIndividuallyOnly || p.VisibleIndividually) &&
                    (vendorId == 0 || p.VendorId == vendorId) &&
                    (
                        warehouseId == 0 ||
                        (
                            !p.UseMultipleWarehouses ? p.WarehouseId == warehouseId :
                                _productWarehouseInventoryRepository.Table.Any(pwi => pwi.WarehouseId == warehouseId && pwi.ProductId == p.Id)
                        )
                    ) &&
                    (productType == null || p.ProductTypeId == (int)productType) &&
                    (
                        showHidden ||
                        (
                            DateTime.UtcNow >= (p.AvailableStartDateTimeUtc ?? DateTime.MinValue) &&
                            DateTime.UtcNow <= (p.AvailableEndDateTimeUtc ?? DateTime.MaxValue)
                        )
                    ) &&
                    (priceMin == null || p.Price >= priceMin) &&
                    (priceMax == null || p.Price <= priceMax)
                );

            if (!string.IsNullOrEmpty(keywords))
            {
                var langs = await _languageService.GetAllLanguagesAsync(showHidden: true);

                //Set a flag which will to points need to search in localized properties. If showHidden doesn't set to true should be at least two published languages.
                var searchLocalizedValue = languageId > 0 && langs.Count >= 2 && (showHidden || langs.Count(l => l.Published) >= 2);

                IQueryable<int> productsByKeywords;

                productsByKeywords =
                        from p in _productRepository.Table
                        where p.Name.Contains(keywords) ||
                            (searchDescriptions &&
                                (p.ShortDescription.Contains(keywords) || p.FullDescription.Contains(keywords))) ||
                            (searchManufacturerPartNumber && p.ManufacturerPartNumber == keywords) ||
                            (searchSku && p.Sku == keywords)
                        select p.Id;

                //search by SKU for ProductAttributeCombination
                if (searchSku)
                {
                    productsByKeywords = productsByKeywords.Union(
                        from pac in _productAttributeCombinationRepository.Table
                        where pac.Sku == keywords
                        select pac.ProductId);
                }

                if (searchProductTags)
                {
                    productsByKeywords = productsByKeywords.Union(
                        from pptm in _productTagMappingRepository.Table
                        join pt in _productTagRepository.Table on pptm.ProductTagId equals pt.Id
                        where pt.Name == keywords
                        select pptm.ProductId
                    );

                    if (searchLocalizedValue)
                    {
                        productsByKeywords = productsByKeywords.Union(
                        from pptm in _productTagMappingRepository.Table
                        join lp in _localizedPropertyRepository.Table on pptm.ProductTagId equals lp.EntityId
                        where lp.LocaleKeyGroup == nameof(ProductTag) &&
                              lp.LocaleKey == nameof(ProductTag.Name) &&
                              lp.LocaleValue.Contains(keywords)
                        select lp.EntityId);
                    }
                }

                if (searchLocalizedValue)
                {
                    productsByKeywords = productsByKeywords.Union(
                                from lp in _localizedPropertyRepository.Table
                                let checkName = lp.LocaleKey == nameof(Core.Domain.Entities.Product.Name) &&
                                                lp.LocaleValue.Contains(keywords)
                                let checkShortDesc = searchDescriptions &&
                                                lp.LocaleKey == nameof(Core.Domain.Entities.Product.ShortDescription) &&
                                                lp.LocaleValue.Contains(keywords)
                                let checkProductTags = searchProductTags &&
                                                lp.LocaleKeyGroup == nameof(ProductTag) &&
                                                lp.LocaleKey == nameof(ProductTag.Name) &&
                                                lp.LocaleValue.Contains(keywords)
                                where
                                    lp.LocaleKeyGroup == nameof(Core.Domain.Entities.Product) && lp.LanguageId == languageId && (checkName || checkShortDesc) ||
                                    checkProductTags

                                select lp.EntityId);
                }

                productsQuery =
                    from p in productsQuery
                    join pbk in productsByKeywords on p.Id equals pbk
                    select p;
            }

            if (categoryIds is not null)
            {
                if (categoryIds.Contains(0))
                    categoryIds.Remove(0);

                if (categoryIds.Any())
                {
                    var productCategoryQuery =
                        from pc in _productCategoryRepository.Table
                        where (!excludeFeaturedProducts || !pc.IsFeaturedProduct) &&
                            categoryIds.Contains(pc.CategoryId)
                        group pc by pc.ProductId into pc
                        select new
                        {
                            ProductId = pc.Key,
                            DisplayOrder = pc.First().DisplayOrder
                        };

                    productsQuery =
                        from p in productsQuery
                        join pc in productCategoryQuery on p.Id equals pc.ProductId
                        orderby pc.DisplayOrder, p.Name
                        select p;
                }
            }

            if (manufacturerIds is not null)
            {
                if (manufacturerIds.Contains(0))
                    manufacturerIds.Remove(0);

                if (manufacturerIds.Any())
                {
                    var productManufacturerQuery =
                        from pm in _productManufacturerRepository.Table
                        where (!excludeFeaturedProducts || !pm.IsFeaturedProduct) &&
                            manufacturerIds.Contains(pm.ManufacturerId)
                        group pm by pm.ProductId into pm
                        select new
                        {
                            ProductId = pm.Key,
                            DisplayOrder = pm.First().DisplayOrder
                        };

                    productsQuery =
                        from p in productsQuery
                        join pm in productManufacturerQuery on p.Id equals pm.ProductId
                        orderby pm.DisplayOrder, p.Name
                        select p;
                }
            }

            if (productTagId > 0)
            {
                productsQuery =
                    from p in productsQuery
                    join ptm in _productTagMappingRepository.Table on p.Id equals ptm.ProductId
                    where ptm.ProductTagId == productTagId
                    select p;
            }

            if (filteredSpecOptions?.Count > 0)
            {
                var specificationAttributeIds = filteredSpecOptions
                    .Select(sao => sao.SpecificationAttributeId)
                    .Distinct();

                foreach (var specificationAttributeId in specificationAttributeIds)
                {
                    var optionIdsBySpecificationAttribute = filteredSpecOptions
                        .Where(o => o.SpecificationAttributeId == specificationAttributeId)
                        .Select(o => o.Id);

                    var productSpecificationQuery =
                        from psa in _productSpecificationAttributeRepository.Table
                        where psa.AllowFiltering && optionIdsBySpecificationAttribute.Contains(psa.SpecificationAttributeOptionId)
                        select psa;

                    productsQuery =
                        from p in productsQuery
                        where productSpecificationQuery.Any(pc => pc.ProductId == p.Id)
                        select p;
                }
            }

            return await productsQuery.OrderBy(_localizedPropertyRepository, await _workContext.GetWorkingLanguageAsync(), orderBy).ToPagedListAsync(pageIndex, pageSize);
        }

        /// <summary>
        /// Gets all product reviews
        /// </summary>
        /// <param name="customerId">Customer identifier (who wrote a review); 0 to load all records</param>
        /// <param name="approved">A value indicating whether to content is approved; null to load all records</param> 
        /// <param name="fromUtc">Item creation from; null to load all records</param>
        /// <param name="toUtc">Item item creation to; null to load all records</param>
        /// <param name="message">Search title or review text; null to load all records</param>
        /// <param name="storeId">The store identifier, where a review has been created; pass 0 to load all records</param>
        /// <param name="productId">The product identifier; pass 0 to load all records</param>
        /// <param name="vendorId">The vendor identifier (limit to products of this vendor); pass 0 to load all records</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the reviews
        /// </returns>
        public virtual async Task<IPagedList<Productreview>> GetAllProductReviewsAsync(int customerId = 0, bool? approved = null,
            DateTime? fromUtc = null, DateTime? toUtc = null,
            string message = null, int storeId = 0, int productId = 0, int vendorId = 0, bool showHidden = false,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var productReviews = await _productReviewRepository.GetAllPagedAsync(async query =>
            {
                if (!showHidden)
                {
                    var productsQuery = _productRepository.Table.Where(p => p.Published);

                    //apply store mapping constraints
                    productsQuery = await _storeMappingService.ApplyStoreMapping(productsQuery, storeId);

                    //apply ACL constraints
                    var customer = await _workContext.GetCurrentCustomerAsync();
                    productsQuery = await _aclService.ApplyAcl(productsQuery, customer);

                    query = query.Where(review => productsQuery.Any(product => product.Id == review.ProductId));
                }

                if (approved.HasValue)
                    query = query.Where(pr => pr.IsApproved == approved);
                if (customerId > 0)
                    query = query.Where(pr => pr.CustomerId == customerId);
                if (fromUtc.HasValue)
                    query = query.Where(pr => fromUtc.Value <= pr.CreatedOnUtc);
                if (toUtc.HasValue)
                    query = query.Where(pr => toUtc.Value >= pr.CreatedOnUtc);
                if (!string.IsNullOrEmpty(message))
                    query = query.Where(pr => pr.Title.Contains(message) || pr.ReviewText.Contains(message));
                if (storeId > 0)
                    query = query.Where(pr => pr.StoreId == storeId);
                if (productId > 0)
                    query = query.Where(pr => pr.ProductId == productId);

                query = from productReview in query
                        join product in _productRepository.Table on productReview.ProductId equals product.Id
                        where
                            (vendorId == 0 || product.VendorId == vendorId) &&
                            //ignore deleted products
                            !product.Deleted
                        select productReview;

                query = _catalogSettings.ProductReviewsSortByCreatedDateAscending
                    ? query.OrderBy(pr => pr.CreatedOnUtc).ThenBy(pr => pr.Id)
                    : query.OrderByDescending(pr => pr.CreatedOnUtc).ThenBy(pr => pr.Id);

                return query;
            }, pageIndex, pageSize);

            return productReviews;
        }



        /// <summary>
        /// Get number of product (published and visible) in certain category
        /// </summary>
        /// <param name="categoryIds">Category identifiers</param>
        /// <param name="storeId">Store identifier; 0 to load all records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the number of products
        /// </returns>
        public virtual async Task<int> GetNumberOfProductsInCategoryAsync(IList<int> categoryIds = null, int storeId = 0)
        {
            //validate "categoryIds" parameter
            if (categoryIds != null && categoryIds.Contains(0))
                categoryIds.Remove(0);

            var query = _productRepository.Table.Where(p => p.Published && !p.Deleted && p.VisibleIndividually);

            //apply store mapping constraints
            query = await _storeMappingService.ApplyStoreMapping(query, storeId);

            //apply ACL constraints
            var customer = await _workContext.GetCurrentCustomerAsync();
            var customerRoleIds = await _customerService.GetCustomerRoleIdsAsync(customer);
            query = await _aclService.ApplyAcl(query, customerRoleIds);

            //category filtering
            if (categoryIds != null && categoryIds.Any())
            {
                query = from p in query
                        join pc in _productCategoryRepository.Table on p.Id equals pc.ProductId
                        where categoryIds.Contains(pc.CategoryId)
                        select p;
            }

            var cacheKey = _staticCacheManager
                .PrepareKeyForDefaultCache(PreepexCatalogDefaults.CategoryProductsNumberCacheKey, customerRoleIds, storeId, categoryIds);

            //only distinct products
            return await _staticCacheManager.GetAsync(cacheKey, () => query.Select(p => p.Id).Count());
        }


        /// <summary>
        /// Gets featured products by manufacturer identifier
        /// </summary>
        /// <param name="manufacturerId">Manufacturer identifier</param>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the list of featured products
        /// </returns>
        public virtual async Task<IList<Core.Domain.Entities.Product>> GetManufacturerFeaturedProductsAsync(int manufacturerId, int storeId = 0)
        {
            IList<Core.Domain.Entities.Product> featuredProducts = new List<Core.Domain.Entities.Product>();

            if (manufacturerId == 0)
                return featuredProducts;

            var customer = await _workContext.GetCurrentCustomerAsync();
            var customerRoleIds = await _customerService.GetCustomerRoleIdsAsync(customer);
            var cacheKey = _staticCacheManager.PrepareKeyForDefaultCache(PreepexCatalogDefaults.ManufacturerFeaturedProductIdsKey, manufacturerId, customerRoleIds, storeId);

            var featuredProductIds = await _staticCacheManager.GetAsync(cacheKey, async () =>
            {
                var query = from p in _productRepository.Table
                            join pm in _productManufacturerRepository.Table on p.Id equals pm.ProductId
                            where p.Published && !p.Deleted && p.VisibleIndividually &&
                                pm.IsFeaturedProduct && manufacturerId == pm.ManufacturerId
                            select p;

                //apply store mapping constraints
                query = await _storeMappingService.ApplyStoreMapping(query, storeId);

                //apply ACL constraints
                query = await _aclService.ApplyAcl(query, customerRoleIds);

                featuredProducts = query.ToList();

                return featuredProducts.Select(p => p.Id).ToList();
            });

            if (featuredProducts.Count == 0 && featuredProductIds.Count > 0)
                featuredProducts = await _productRepository.GetByIdsAsync(featuredProductIds, cache => default, false);

            return featuredProducts;
        }

        /// <summary>
        /// Get total quantity
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="useReservedQuantity">
        /// A value indicating whether we should consider "Reserved Quantity" property 
        /// when "multiple warehouses" are used
        /// </param>
        /// <param name="warehouseId">
        /// Warehouse identifier. Used to limit result to certain warehouse.
        /// Used only with "multiple warehouses" enabled.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the result
        /// </returns>
        public virtual async Task<int> GetTotalStockQuantityAsync(Core.Domain.Entities.Product product, bool useReservedQuantity = true, int warehouseId = 0)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (product.ManageInventoryMethod != ManageInventoryMethod.ManageStock)
                //We can calculate total stock quantity when 'Manage inventory' property is set to 'Track inventory'
                return 0;

            if (!product.UseMultipleWarehouses)
                return product.StockQuantity;

            var pwi = _productWarehouseInventoryRepository.Table.Where(wi => wi.ProductId == product.Id);

            if (warehouseId > 0)
                pwi = pwi.Where(x => x.WarehouseId == warehouseId);

            var result = await pwi.SumAsync(x => x.StockQuantity);
            if (useReservedQuantity)
                result -= await pwi.SumAsync(x => x.ReservedQuantity);

            return result;
        }

        /// <summary>
        /// Gets featured products by a category identifier
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the list of featured products
        /// </returns>
        public virtual async Task<IList<Core.Domain.Entities.Product>> GetCategoryFeaturedProductsAsync(int categoryId, int storeId = 0)
        {
            IList<Core.Domain.Entities.Product> featuredProducts = new List<Core.Domain.Entities.Product>();

            if (categoryId == 0)
                return featuredProducts;

            var customer = await _workContext.GetCurrentCustomerAsync();
            var customerRoleIds = await _customerService.GetCustomerRoleIdsAsync(customer);
            var cacheKey = _staticCacheManager.PrepareKeyForDefaultCache(PreepexCatalogDefaults.CategoryFeaturedProductsIdsKey, categoryId, customerRoleIds, storeId);

            var featuredProductIds = await _staticCacheManager.GetAsync(cacheKey, async () =>
            {
                var query = from p in _productRepository.Table
                            join pc in _productCategoryRepository.Table on p.Id equals pc.ProductId
                            where p.Published && !p.Deleted && p.VisibleIndividually &&
                                pc.IsFeaturedProduct && categoryId == pc.CategoryId
                            select p;

                //apply store mapping constraints
                query = await _storeMappingService.ApplyStoreMapping(query, storeId);

                //apply ACL constraints
                query = await _aclService.ApplyAcl(query, customerRoleIds);

                featuredProducts = query.ToList();

                return featuredProducts.Select(p => p.Id).ToList();
            });

            if (featuredProducts.Count == 0 && featuredProductIds.Count > 0)
                featuredProducts = await _productRepository.GetByIdsAsync(featuredProductIds, cache => default, false);

            return featuredProducts;
        }
    }
}
