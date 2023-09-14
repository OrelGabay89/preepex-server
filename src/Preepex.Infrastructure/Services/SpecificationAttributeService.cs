using Microsoft.EntityFrameworkCore;
using Preepex.Core.Application.Caching;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Application.Interfaces.Security;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Domain.Entities;
using Preepex.Core.Domain.Entities.Catalog;
using Preepex.Infrastructure.Extensions;
using Preepex.Infrastructure.Services.Catalog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Services
{
    public class SpecificationAttributeService : ISpecificationAttributeService
    {
        private readonly CatalogSettings _catalogSettings;
        private readonly IAclService _aclService;
        private readonly ICategoryService _categoryService;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;

        private readonly IGenericRepository<ProductSpecificationattributeMapping> _productSpecificationAttributeRepository;

        private readonly IGenericRepository<Specificationattribute> _specificationAttributeRepository;
        private readonly IGenericRepository<Specificationattributeoption> _specificationAttributeOptionRepository;
        private readonly IGenericRepository<Specificationattributegroup> _specificationAttributeGroupRepository;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IWorkContext _workContext;



        public SpecificationAttributeService(CatalogSettings catalogSettings,
            IAclService aclService, ICategoryService categoryService,
            IGenericRepository<Product> productRepository,
            IGenericRepository<ProductCategory> productCategoryRepository,
            IGenericRepository<ProductSpecificationattributeMapping> productSpecificationAttributeRepository,
            IGenericRepository<Specificationattribute> specificationAttributeRepository,
            IGenericRepository<Specificationattributeoption> specificationAttributeOptionRepository,
            IGenericRepository<Specificationattributegroup> specificationAttributeGroupRepository,
            IStoreContext storeContext, IStoreMappingService storeMappingService,
            IStaticCacheManager staticCacheManager, IWorkContext workContext)
        {

            _catalogSettings = catalogSettings;
            _aclService = aclService;
            _categoryService = categoryService; ;
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _productSpecificationAttributeRepository = productSpecificationAttributeRepository;
            _specificationAttributeRepository = specificationAttributeRepository;
            _specificationAttributeOptionRepository = specificationAttributeOptionRepository;
            _specificationAttributeGroupRepository = specificationAttributeGroupRepository;
            _storeContext = storeContext;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
            _storeMappingService = storeMappingService;
        }


        /// <summary>
        /// Gets product specification attribute groups
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the specification attribute groups
        /// </returns>
        public virtual async Task<IList<Specificationattributegroup>> GetProductSpecificationAttributeGroupsAsync(int productId)
        {
            var productAttributesForGroupQuery =
              from sa in _specificationAttributeRepository.Table
              join sao in _specificationAttributeOptionRepository.Table
                  on sa.Id equals sao.SpecificationAttributeId
              join psa in _productSpecificationAttributeRepository.Table
                  on sao.Id equals psa.SpecificationAttributeOptionId
              where psa.ProductId == productId && psa.ShowOnProductPage
              select sa.SpecificationAttributeGroupId;

            var availableGroupsQuery =
                from sag in _specificationAttributeGroupRepository.Table
                where productAttributesForGroupQuery.Any(groupId => groupId == sag.Id)
                select sag;

            var key = _staticCacheManager.PrepareKeyForDefaultCache(PreepexCatalogDefaults.SpecificationAttributeGroupByProductCacheKey, productId);

            return await _staticCacheManager.GetAsync(key, async () => await availableGroupsQuery.ToListAsync());// _staticCacheManager.GetAsync(key, async () => await availableGroupsQuery.ToListAsync());
        }

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
        /// 
        public virtual async Task<IList<ProductSpecificationattributeMapping>> GetProductSpecificationAttributesAsync(int productId = 0,
        int specificationAttributeOptionId = 0, bool? allowFiltering = null, bool? showOnProductPage = null, int? specificationAttributeGroupId = 0)
        {
            var allowFilteringCacheStr = allowFiltering.HasValue ? allowFiltering.ToString() : "null";
            var showOnProductPageCacheStr = showOnProductPage.HasValue ? showOnProductPage.ToString() : "null";
            var specificationAttributeGroupIdCacheStr = specificationAttributeGroupId.HasValue ? specificationAttributeGroupId.ToString() : "null";

            var key = _staticCacheManager.PrepareKeyForDefaultCache(PreepexCatalogDefaults.ProductSpecificationAttributeByProductCacheKey,
                productId, specificationAttributeOptionId, allowFilteringCacheStr, showOnProductPageCacheStr, specificationAttributeGroupIdCacheStr);

            var query = _productSpecificationAttributeRepository.Table.Select(x=>x);
            var query2 = await _productSpecificationAttributeRepository.ListAllAsync();
            if (productId > 0)
                query = query.Where(psa => psa.ProductId == productId);
            if (specificationAttributeOptionId > 0)
                query = query.Where(psa => psa.SpecificationAttributeOptionId == specificationAttributeOptionId);
            if (allowFiltering.HasValue)
                query = query.Where(psa => psa.AllowFiltering == allowFiltering.Value);
            if (!specificationAttributeGroupId.HasValue || specificationAttributeGroupId > 0)
            {
                query = from psa in query
                        join sao in _specificationAttributeOptionRepository.Table
                            on psa.SpecificationAttributeOptionId equals sao.Id
                        join sa in _specificationAttributeRepository.Table
                            on sao.SpecificationAttributeId equals sa.Id
                        where sa.SpecificationAttributeGroupId == specificationAttributeGroupId
                        select psa;
            }
            if (showOnProductPage.HasValue)
                query = query.Where(psa => psa.ShowOnProductPage == showOnProductPage.Value);
            query = query.OrderBy(psa => psa.DisplayOrder).ThenBy(psa => psa.Id);

            var productSpecificationAttributes = await _staticCacheManager.GetAsync(key, async () => await query.ToListAsync());

            return productSpecificationAttributes;
        }


        /// <summary>
        /// Gets a specification attribute
        /// </summary>
        /// <param name="specificationAttributeId">The specification attribute identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the specification attribute
        /// </returns>
        public virtual async Task<Specificationattribute> GetSpecificationAttributeByIdAsync(int specificationAttributeId)
        {
            return await _specificationAttributeRepository.GetByIdAsync(specificationAttributeId, cache => default);
        }

        /// <summary>
        /// Gets a specification attribute option
        /// </summary>
        /// <param name="specificationAttributeOptionId">The specification attribute option identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the specification attribute option
        /// </returns>
        public virtual async Task<Specificationattributeoption> GetSpecificationAttributeOptionByIdAsync(int specificationAttributeOptionId)
        {
            return await _specificationAttributeOptionRepository.GetByIdAsync(specificationAttributeOptionId, cache => default);
        }



        public virtual async Task<IPagedList<Product>> GetProductsBySpecificationAttributeIdAsync(int specificationAttributeId, int pageIndex, int pageSize)
        {
            var query = from product in _productRepository.Table
                        join psa in _productSpecificationAttributeRepository.Table on product.Id equals psa.ProductId
                        join spao in _specificationAttributeOptionRepository.Table on psa.SpecificationAttributeOptionId equals spao.Id
                        where spao.SpecificationAttributeId == specificationAttributeId
                        orderby product.Name
                        select product;

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }
    }
}
