using LinqToDB;
using Swiftrade.Core.Application.Caching;
using Swiftrade.Core.Application.Interfaces;
using Swiftrade.Core.Application.Interfaces.Security;
using Swiftrade.Core.Application.Interfaces.Shared;
using Swiftrade.Core.Application.Interfaces.Shared.Catalog;
using Swiftrade.Core.Application.Interfaces.Shared.Customers;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Core.Domain.NopEntities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swiftrade.Infrastructure.Services.Catalog
{
    public class ProductTagService : IProductTagService
    {
        private readonly IWorkContext _workContext;

        private readonly IGenericRepository<ProductProducttagMapping> _productProductTagMappingRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductTag> _productTagRepository;


        private readonly IStaticCacheManager _staticCacheManager;
        protected readonly ICustomerService _customerService;
        protected readonly IAclService _aclService;
        private readonly IStoreMappingService _storeMappingService;



        public ProductTagService(
            IGenericRepository<ProductProducttagMapping> productProductTagMappingRepository,
            IGenericRepository<Product> productRepository,
            IGenericRepository<ProductTag> productTagRepository,
            ICustomerService customerService,
            IWorkContext workContext, IStaticCacheManager staticCacheManager,
            IStoreMappingService storeMappingService, IAclService aclService)
        {
            _productProductTagMappingRepository = productProductTagMappingRepository;
            _productRepository = productRepository;
            _productTagRepository = productTagRepository;
            _storeMappingService = storeMappingService;

            _workContext = workContext;
            _staticCacheManager = staticCacheManager;
            _customerService = customerService;
            _aclService = aclService;
        }
        public async Task<List<ProductTag>> GetAllProductTagsByProductIdAsync(int productId)
        {
            var key = _staticCacheManager.PrepareKeyForDefaultCache(SwiftradeCatalogDefaults.ProductTagsByProductCacheKey, productId);

            return await _staticCacheManager.GetAsync(key, async () =>
            {
                var query = _productRepository.Table.SelectMany(pt => pt.ProductTag);

                var tagMapping = query.Where(x => x.Product.All(ptm => ptm.Id == productId)).OrderBy(pt => pt.Id).Select(pt => pt);

                return await tagMapping.ToListAsync();
            });
        }
        public async Task<int> GetProductCountByProductTagIdAsync(int productTagId, int storeId, bool showHidden = false)
        {
            var dictionary = await GetProductCountAsync(storeId, showHidden);
            if (dictionary.ContainsKey(productTagId))
                return dictionary[productTagId];

            return 0;
        }

        public virtual async Task<IList<ProductTag>> GetAllProductTagsAsync(string tagName = null)
        {
            var allProductTags = await _productTagRepository.GetAllAsync(query => query, getCacheKey: cache => default);

            if (!string.IsNullOrEmpty(tagName))
                allProductTags = allProductTags.Where(tag => tag.Name.Contains(tagName)).ToList();

            return allProductTags;
        }

        public async Task<List<int>> GetProductIdsByTagNameAsync(string tagName)
        {
            var key = _staticCacheManager.PrepareKeyForDefaultCache(SwiftradeCatalogDefaults.ProductTagsByProductCacheKey, tagName);

            return await _staticCacheManager.GetAsync(key, async () =>
            {
                var tagMapping = _productRepository.Table
                                    .SelectMany(pt => pt.ProductTag)
                                    .Where(x => x.Name.ToLower().Contains(tagName))
                                    .SelectMany(x => x.Product).Select(x => x.Id);

                return await tagMapping.ToListAsync();
            });

        }

        public virtual async Task<Dictionary<int, int>> GetProductCountAsync(int storeId, bool showHidden = false)
        {
            var customer = await _workContext.GetCurrentCustomerAsync();

            var customerRoleIds = await _customerService.GetCustomerRoleIdsAsync(customer);

            var key = _staticCacheManager.PrepareKeyForDefaultCache(SwiftradeCatalogDefaults.ProductTagCountCacheKey, storeId, "test", showHidden);

            return await _staticCacheManager.GetAsync(key, async () =>
            {
                var query = _productRepository.Table.SelectMany(x => x.ProductTag);

                if (!showHidden)
                {
                    var productsQuery = _productRepository.Table.Where(p => p.Published);

                    //apply store mapping constraints
                    productsQuery = await _storeMappingService.ApplyStoreMapping(productsQuery, storeId);

                    //apply ACL constraints
                    productsQuery = await _aclService.ApplyAcl(productsQuery, customerRoleIds);

                    query = query.Where(pc => productsQuery.Any(p => !p.Deleted));
                }

                var pTagCount = query.GroupBy(x => x.Id).Select(x => new { ProductTagId = x.Key, ProductCount = x.Count() });

                return pTagCount.ToDictionary(item => item.ProductTagId, item => item.ProductCount);

            });
        }


    }
}
