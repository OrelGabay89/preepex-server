using Preepex.Core.Application.Caching;
using Preepex.Core.Domain.Entities;

namespace Preepex.Infrastructure.Services.Catalog
{
    /// <summary>
    /// Represents default values related to catalog services
    /// </summary>
    public static partial class PreepexCatalogDefaults
    {
        #region Common

        /// <summary>
        /// Gets a default price range 'from'
        /// </summary>
        public static decimal DefaultPriceRangeFrom => 0;

        /// <summary>
        /// Gets a default price range 'to'
        /// </summary>
        public static decimal DefaultPriceRangeTo => 10000;

        #endregion

        #region Products

        /// <summary>
        /// Gets a template of product name on copying
        /// </summary>
        /// <remarks>
        /// {0} : product name
        /// </remarks>
        public static string ProductCopyNameTemplate => "Copy of {0}";

        /// <summary>
        /// Gets default prefix for product
        /// </summary>
        public static string ProductAttributePrefix => "product_attribute_";

        #endregion

        #region Caching defaults

        #region Categories

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : parent category ID
        /// {1} : show hidden records?
        /// {2} : current customer ID
        /// {3} : store ID
        /// </remarks>
        public static CacheKey CategoriesByParentCategoryCacheKey => new("Preepex.category.byparent.{0}-{1}-{2}-{3}", CategoriesByParentCategoryPrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        /// <remarks>
        /// {0} : parent category ID
        /// </remarks>
        public static string CategoriesByParentCategoryPrefix => "Preepex.category.byparent.{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : parent category id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// {3} : show hidden records?
        /// </remarks>
        public static CacheKey CategoriesChildIdsCacheKey => new("Preepex.category.childids.{0}-{1}-{2}-{3}", CategoriesChildIdsPrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        /// <remarks>
        /// {0} : parent category ID
        /// </remarks>
        public static string CategoriesChildIdsPrefix => "Preepex.category.childids.{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static CacheKey CategoriesHomepageCacheKey => new("Preepex.category.homepage.", CategoriesHomepagePrefix);

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : current store ID
        /// {1} : roles of the current user
        /// </remarks>
        public static CacheKey CategoriesHomepageWithoutHiddenCacheKey => new("Preepex.category.homepage.withouthidden-{0}-{1}", CategoriesHomepagePrefix);

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : current store ID
        /// {1} : roles of the current user
        /// </remarks>
        public static CacheKey StoreCategories => new("Preepex.category.store-{0}");

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string CategoriesHomepagePrefix => "Preepex.category.homepage.";

        /// <summary>
        /// Key for caching of category breadcrumb
        /// </summary>
        /// <remarks>
        /// {0} : category id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// {3} : language ID
        /// </remarks>
        public static CacheKey CategoryBreadcrumbCacheKey => new("Preepex.category.breadcrumb.{0}-{1}-{2}-{3}", CategoryBreadcrumbPrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string CategoryBreadcrumbPrefix => "Preepex.category.breadcrumb.";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : current store ID
        /// {1} : roles of the current user
        /// {2} : show hidden records?
        /// </remarks>
        public static CacheKey CategoriesAllCacheKey => new("Preepex.category.all.{0}-{1}-{2}", EntityCacheDefaults<Category>.AllPrefix);

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : product ID
        /// {1} : show hidden records?
        /// {2} : current customer ID
        /// {3} : store ID
        /// </remarks>
        public static CacheKey ProductCategoriesByProductCacheKey => new("Preepex.productcategory.byproduct.{0}-{1}-{2}-{3}", ProductCategoriesByProductPrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string ProductCategoriesByProductPrefix => "Preepex.productcategory.byproduct.{0}";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer roles ID hash
        /// {1} : current store ID
        /// {2} : categories ID hash
        /// </remarks>
        public static CacheKey CategoryProductsNumberCacheKey => new("Preepex.productcategory.products.number.{0}-{1}-{2}", CategoryProductsNumberPrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string CategoryProductsNumberPrefix => "Preepex.productcategory.products.number.";

        #endregion

        #region Manufacturers

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : product ID
        /// {1} : show hidden records?
        /// {2} : current customer ID
        /// {3} : store ID
        /// </remarks>
        public static CacheKey ProductManufacturersByProductCacheKey => new("Preepex.productmanufacturer.byproduct.{0}-{1}-{2}-{3}", ProductManufacturersByProductPrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        /// <remarks>
        /// {0} : product ID
        /// </remarks>
        public static string ProductManufacturersByProductPrefix => "Preepex.productmanufacturer.byproduct.{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : category ID
        /// </remarks>
        public static CacheKey ManufacturersByCategoryCacheKey => new("Preepex.manufacturer.bycategory.{0}", ManufacturersByCategoryPrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string ManufacturersByCategoryPrefix => "Preepex.manufacturer.bycategory.";

        #endregion

        #region Products

        /// <summary>
        /// Key for "related" product displayed on the product details page
        /// </summary>
        /// <remarks>
        /// {0} : current product id
        /// {1} : show hidden records?
        /// </remarks>
        public static CacheKey RelatedProductsCacheKey => new("Preepex.relatedproduct.byproduct.{0}-{1}", RelatedProductsPrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        /// <remarks>
        /// {0} : product ID
        /// </remarks>
        public static string RelatedProductsPrefix => "Preepex.relatedproduct.byproduct.{0}";

        /// <summary>
        /// Key for "related" product identifiers displayed on the product details page
        /// </summary>
        /// <remarks>
        /// {0} : current product id
        /// </remarks>
        public static CacheKey TierPricesByProductCacheKey => new("Preepex.tierprice.byproduct.{0}");

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static CacheKey ProductsHomepageCacheKey => new("Preepex.product.homepage.");

        /// <summary>
        /// Key for caching identifiers of category featured products
        /// </summary>
        /// <remarks>
        /// {0} : category id
        /// {1} : customer role Ids
        /// {2} : current store ID
        /// </remarks>
        public static CacheKey CategoryFeaturedProductsIdsKey => new("Preepex.product.featured.bycategory.{0}-{1}-{2}", CategoryFeaturedProductsIdsPrefix, FeaturedProductIdsPrefix);
        public static string CategoryFeaturedProductsIdsPrefix => "Preepex.product.featured.bycategory.{0}";

        /// <summary>
        /// Key for caching of a value indicating whether a manufacturer has featured products
        /// </summary>
        /// <remarks>
        /// {0} : manufacturer id
        /// {1} : customer role Ids
        /// {2} : current store ID
        /// </remarks>
        public static CacheKey ManufacturerFeaturedProductIdsKey => new("Preepex.product.featured.bymanufacturer.{0}-{1}-{2}", ManufacturerFeaturedProductIdsPrefix, FeaturedProductIdsPrefix);
        public static string ManufacturerFeaturedProductIdsPrefix => "Preepex.product.featured.bymanufacturer.{0}";

        public static string FeaturedProductIdsPrefix => "Preepex.product.featured.";

        /// <summary>
        /// Gets a key for product prices
        /// </summary>
        /// <remarks>
        /// {0} : product id
        /// {1} : overridden product price
        /// {2} : additional charge
        /// {3} : include discounts (true, false)
        /// {4} : quantity
        /// {5} : roles of the current user
        /// {6} : current store ID
        /// </remarks>
        public static CacheKey ProductPriceCacheKey => new("Preepex.totals.productprice.{0}-{1}-{2}-{3}-{4}-{5}-{6}", ProductPricePrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        /// <remarks>
        /// {0} : product id
        /// </remarks>
        public static string ProductPricePrefix => "Preepex.totals.productprice.{0}";

        #endregion

        #region Product attributes

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : product ID
        /// </remarks>
        public static CacheKey ProductAttributeMappingsByProductCacheKey => new("Preepex.productattributemapping.byproduct.{0}");

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : product attribute mapping ID
        /// </remarks>
        public static CacheKey ProductAttributeValuesByAttributeCacheKey => new("Preepex.productattributevalue.byattribute.{0}");

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : product ID
        /// </remarks>
        public static CacheKey ProductAttributeCombinationsByProductCacheKey => new("Preepex.productattributecombination.byproduct.{0}");

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : Product attribute ID
        /// </remarks>
        public static CacheKey PredefinedProductAttributeValuesByAttributeCacheKey => new("Preepex.predefinedproductattributevalue.byattribute.{0}");

        #endregion

        #region Product tags

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : store ID
        /// {1} : hash of list of customer roles IDs
        /// {2} : show hidden records?
        /// </remarks>
        public static CacheKey ProductTagCountCacheKey => new("Preepex.producttag.count.{0}-{1}-{2}", EntityCacheDefaults<ProductTag>.Prefix);

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : product ID
        /// </remarks>
        public static CacheKey ProductTagsByProductCacheKey => new("Preepex.producttag.byproduct.{0}", EntityCacheDefaults<ProductTag>.Prefix);

        #endregion

        #region Review type

        /// <summary>
        /// Key for caching product review and review type mapping
        /// </summary>
        /// <remarks>
        /// {0} : product review ID
        /// </remarks>
        public static CacheKey ProductReviewTypeMappingByReviewTypeCacheKey => new("Preepex.productreviewreviewtypemapping.byreviewtype.{0}");

        #endregion

        #region Specification attributes

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : product ID
        /// {1} : specification attribute option ID
        /// {2} : allow filtering
        /// {3} : show on product page
        /// {4} : specification attribute group ID
        /// </remarks>
        public static CacheKey ProductSpecificationAttributeByProductCacheKey => new("Preepex.productspecificationattribute.byproduct.{0}-{1}-{2}-{3}-{4}", ProductSpecificationAttributeByProductPrefix, ProductSpecificationAttributeAllByProductPrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        /// <remarks>
        /// {0} : product ID
        /// </remarks>
        public static string ProductSpecificationAttributeByProductPrefix => "Preepex.productspecificationattribute.byproduct.{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        /// <remarks>
        /// {1} (not 0, see the <ref>ProductSpecificationAttributeAllByProductIdCacheKey</ref>) :specification attribute option ID
        /// </remarks>
        public static string ProductSpecificationAttributeAllByProductPrefix => "Preepex.productspecificationattribute.byproduct.";

        /// <summary>
        /// Key for specification attributes caching (product details page)
        /// </summary>
        public static CacheKey SpecificationAttributesWithOptionsCacheKey => new("Preepex.specificationattribute.withoptions.");

        /// <summary>
        /// Key for specification attributes caching
        /// </summary>
        /// <remarks>
        /// {0} : specification attribute ID
        /// </remarks>
        public static CacheKey SpecificationAttributeOptionsCacheKey => new("Preepex.specificationattributeoption.byattribute.{0}");

        /// <summary>
        /// Key for specification attribute options by category ID caching
        /// </summary>
        /// <remarks>
        /// {0} : category ID
        /// </remarks>
        public static CacheKey SpecificationAttributeOptionsByCategoryCacheKey => new("Preepex.specificationattributeoption.bycategory.{0}", FilterableSpecificationAttributeOptionsPrefix);

        /// <summary>
        /// Key for specification attribute options by manufacturer ID caching
        /// </summary>
        /// <remarks>
        /// {0} : manufacturer ID
        /// </remarks>
        public static CacheKey SpecificationAttributeOptionsByManufacturerCacheKey => new("Preepex.specificationattributeoption.bymanufacturer.{0}", FilterableSpecificationAttributeOptionsPrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string FilterableSpecificationAttributeOptionsPrefix => "Preepex.filterablespecificationattributeoptions";

        /// <summary>
        /// Gets a key for specification attribute groups caching by product id
        /// </summary>
        /// <remarks>
        /// {0} : product ID
        /// </remarks>
        public static CacheKey SpecificationAttributeGroupByProductCacheKey => new("Preepex.specificationattributegroup.byproduct.{0}", SpecificationAttributeGroupByProductPrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string SpecificationAttributeGroupByProductPrefix => "Preepex.specificationattributegroup.byproduct.";

        #endregion

        #endregion
    }
}