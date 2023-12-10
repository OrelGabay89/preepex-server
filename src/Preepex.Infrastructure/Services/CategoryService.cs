using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Security;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using LinqToDB;
using Preepex.Core.Application.Interfaces.Shared.Customers;
using Preepex.Infrastructure.Extensions;
using Preepex.Infrastructure.Services.Catalog;
using Preepex.Core.Application.Caching;
using Preepex.Core.Application.Models;
using System.Diagnostics;
using Preepex.Common;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Preepex.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
        private readonly IGenericRepository<Storemapping> _storeMappingRepository;

        private readonly IStoreMappingService _storeMappingService;
        private readonly IAclService _aclService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ICustomerService _customerService;


        public CategoryService(
            IGenericRepository<Category> categoryRepository,
            IGenericRepository<Product> productRepository,
            IGenericRepository<ProductCategory> productCategoryRepository,
            IGenericRepository<Storemapping> storeMappingRepository,
            IAclService aclService,
            IStoreMappingService storeMappingService,
            ICustomerService customerService,
            IStoreContext storeContext,
            IWorkContext workContext,
            IStaticCacheManager staticCacheManager
        ) {
            _categoryRepository = categoryRepository;
            _aclService = aclService;
            _customerService = customerService;
            _storeMappingService = storeMappingService;
            _storeContext = storeContext;
            _workContext = workContext;
            _staticCacheManager = staticCacheManager;
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _storeMappingRepository = storeMappingRepository;
        }
        public virtual async Task<IPagedList<Category>> GetAllCategoriesAsync(string categoryName, int storeId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false, bool? overridePublished = null)
        {
            var unsortedCategories = await _categoryRepository.GetAllAsync(async query =>
            {
                if (!showHidden)
                    query = query.Where(c => c.Published);
                else if (overridePublished.HasValue)
                    query = query.Where(c => c.Published == overridePublished.Value);

                //apply store mapping constraints
                query = await _storeMappingService.ApplyStoreMapping(query, storeId);

                //apply ACL constraints
                if (!showHidden)
                {
                    var customer = await _workContext.GetCurrentCustomerAsync();
                    query = await _aclService.ApplyAcl(query, customer);
                }

                if (!string.IsNullOrWhiteSpace(categoryName))
                    query = query.Where(c => c.Name.Contains(categoryName));

                query = query.Where(c => !c.Deleted);

                return query.OrderBy(c => c.ParentCategoryId).ThenBy(c => c.DisplayOrder).ThenBy(c => c.Id);
            });

            //sort categories
            var sortedCategories = await SortCategoriesForTreeAsync(unsortedCategories);

            //paging
            return new PagedList<Category>(sortedCategories, pageIndex, pageSize);
        }


        /// <summary>
        /// Gets all categories displayed on the home page
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the categories
        /// </returns>
        public virtual async Task<IList<Category>> GetAllCategoriesDisplayedOnHomepageAsync(int storeId, bool showHidden = false)
        {

            var storeCategoriesCacheKey = _staticCacheManager.PrepareKeyForDefaultCache(
                PreepexCatalogDefaults.StoreCategories,
                storeId
            );

            return await _staticCacheManager.GetAsync(storeCategoriesCacheKey, async () =>
            {

                var storeMappingCategories = await _storeMappingRepository.Table
                    .Where(x => x.StoreId == storeId)
                    .Where(x => x.EntityName == nameof(Category))
                    .Select(x => x.EntityId)
                    .ToListAsync();

                var categories = await _categoryRepository.Table
                    .Where(c => storeMappingCategories.Contains(c.Id))
                    .Where(c => c.ShowOnHomepage)
                    .Where(c => c.Published)
                    .Where(c => !c.Deleted)
                    .OrderBy(c => c.DisplayOrder)
                    .ThenBy(c => c.Id)
                    .ToListAsync();

                return categories;
            });
        }


        /// <summary>
        /// Sort categories for tree representation
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="parentId">Parent category identifier</param>
        /// <param name="ignoreCategoriesWithoutExistingParent">A value indicating whether categories without parent category in provided category list (source) should be ignored</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the sorted categories
        /// </returns>
        protected virtual async Task<IList<Category>> SortCategoriesForTreeAsync(IList<Category> source, int parentId = 0,
            bool ignoreCategoriesWithoutExistingParent = false)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var result = new List<Category>();

            foreach (var cat in source.Where(c => c.ParentCategoryId == parentId).ToList())
            {
                result.Add(cat);
                result.AddRange(await SortCategoriesForTreeAsync(source, cat.Id, true));
            }

            if (ignoreCategoriesWithoutExistingParent || result.Count == source.Count)
                return result;

            //find categories without parent in provided category source and insert them into result
            foreach (var cat in source)
                if (result.FirstOrDefault(x => x.Id == cat.Id) == null)
                    result.Add(cat);

            return result;
        }


        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the categories
        /// </returns>
        public virtual async Task<IList<Category>> GetAllCategoriesAsync(int storeId = 0, bool showHidden = false)
        {
            var key = _staticCacheManager.PrepareKeyForDefaultCache(PreepexCatalogDefaults.CategoriesAllCacheKey,
                storeId,
                await _customerService.GetCustomerRoleIdsAsync(await _workContext.GetCurrentCustomerAsync()),
                showHidden);

            var categories = await _staticCacheManager
                .GetAsync(key, async () => (await GetAllCategoriesAsync(string.Empty, storeId, showHidden: showHidden)).ToList());

            return categories;
        }

        /// <summary>
        /// Gets child category identifiers
        /// </summary>
        /// <param name="parentCategoryId">Parent category identifier</param>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the category identifiers
        /// </returns>
        public virtual async Task<IList<int>> GetChildCategoryIdsAsync(int parentCategoryId, int storeId = 0, bool showHidden = false)
        {
            var cacheKey = _staticCacheManager.PrepareKeyForDefaultCache(PreepexCatalogDefaults.CategoriesChildIdsCacheKey,
                parentCategoryId,
                await _customerService.GetCustomerRoleIdsAsync(await _workContext.GetCurrentCustomerAsync()),
                storeId,
                showHidden);

            return await _staticCacheManager.GetAsync(cacheKey, async () =>
            {
                //little hack for performance optimization
                //there's no need to invoke "GetAllCategoriesByParentCategoryId" multiple times (extra SQL commands) to load childs
                //so we load all categories at once (we know they are cached) and process them server-side
                var categoriesIds = new List<int>();
                var categories = (await GetAllCategoriesAsync(storeId: storeId, showHidden: showHidden))
                    .Where(c => c.ParentCategoryId == parentCategoryId)
                    .Select(c => c.Id)
                    .ToList();
                categoriesIds.AddRange(categories);
                categoriesIds.AddRange(await categories.SelectManyAwait(async cId => await GetChildCategoryIdsAsync(cId, storeId, showHidden)).ToListAsync());

                return categoriesIds;
            });
        }

        /// <summary>
        /// Gets a category
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the category
        /// </returns>
        public virtual async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _categoryRepository.GetByIdAsync(categoryId, cache => default);
        }


        public async Task<bool> CheckCategoryAvailabilityAsync(Category category)
        {
            var isAvailable = true;

            if (category == null || category.Deleted)
                isAvailable = false;

            var notAvailable =
                //published?
                !category.Published ||
                //ACL (access control list) 
                !await _aclService.AuthorizeAsync(category) ||
                //Store mapping
                !await _storeMappingService.AuthorizeAsync(category);
            //Check whether the current user has a "Manage categories" permission (usually a store owner)
            //We should allows him (her) to use "Preview" functionality
            //var hasAdminAccess = await _permissionService.AuthorizeAsync(StandardPermissionProvider.AccessAdminPanel) && await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories);
            //if (notAvailable && !hasAdminAccess)
            //    isAvailable = false;

            return isAvailable;
        }


        /// <summary>
        /// Get category breadcrumb 
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="allCategories">All categories</param>
        /// <param name="showHidden">A value indicating whether to load hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the category breadcrumb 
        /// </returns>
        public virtual async Task<IList<Category>> GetCategoryBreadCrumbAsync(Category category, IList<Category> allCategories = null, bool showHidden = false)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            var breadcrumbCacheKey = _staticCacheManager.PrepareKeyForDefaultCache(PreepexCatalogDefaults.CategoryBreadcrumbCacheKey,
                category,
                await _customerService.GetCustomerRoleIdsAsync(await _workContext.GetCurrentCustomerAsync()),
                await _storeContext.GetCurrentStoreAsync(),
                await _workContext.GetWorkingLanguageAsync());

            return await _staticCacheManager.GetAsync(breadcrumbCacheKey, async () =>
            {
                var result = new List<Category>();

                //used to prevent circular references
                var alreadyProcessedCategoryIds = new List<int>();

                while (category != null && //not null
                       !category.Deleted && //not deleted
                       (showHidden || category.Published) && //published
                       (showHidden || await _aclService.AuthorizeAsync(category)) && //ACL
                       (showHidden || await _storeMappingService.AuthorizeAsync(category)) && //Store mapping
                       !alreadyProcessedCategoryIds.Contains(category.Id)) //prevent circular references
                {
                    result.Add(category);

                    alreadyProcessedCategoryIds.Add(category.Id);

                    category = allCategories != null
                        ? allCategories.FirstOrDefault(c => c.Id == category.ParentCategoryId)
                        : await GetCategoryByIdAsync(category.ParentCategoryId);
                }

                result.Reverse();

                return result;
            });
        }


        /// <summary>
        /// Gets all categories filtered by parent category identifier
        /// </summary>
        /// <param name="parentCategoryId">Parent category identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the categories
        /// </returns>
        public virtual async Task<IList<Category>> GetAllCategoriesByParentCategoryIdAsync(int parentCategoryId,
            bool showHidden = false)
        {
            var store = await _storeContext.GetCurrentStoreAsync();
            var customer = await _workContext.GetCurrentCustomerAsync();
            var categories = await _categoryRepository.GetAllAsync(async query =>
            {
                if (!showHidden)
                {
                    query = query.Where(c => c.Published);

                    //apply store mapping constraints
                    query = await _storeMappingService.ApplyStoreMapping(query, store.Id);

                    //apply ACL constraints
                    query = await _aclService.ApplyAcl(query, customer);
                }

                query = query.Where(c => !c.Deleted && c.ParentCategoryId == parentCategoryId);

                return query.OrderBy(c => c.DisplayOrder).ThenBy(c => c.Id);
            }, cache => cache.PrepareKeyForDefaultCache(PreepexCatalogDefaults.CategoriesByParentCategoryCacheKey,
                parentCategoryId, showHidden, customer, store));

            return categories;
        }

        public virtual async Task<List<Product>> GetProductsByCategory(int categoryId, CatalogProductsFilter filter)
        {
            var currentStore = await _storeContext.GetCurrentStoreAsync();

            var availableProductIds = await _storeMappingRepository.Table
                .Where(sm => sm.EntityName == nameof(Product))
                .Where(sm => sm.StoreId == currentStore.Id)
                .Select(sm => sm.EntityId)
                .ToListAsync();

            var query = _productCategoryRepository.Table
                .Where(pc => pc.CategoryId == categoryId)
                .Where(pc => availableProductIds.Contains(pc.ProductId))
                .Join(_productRepository.Table, pc => pc.ProductId, p => p.Id, (pc, p) => p)
                .Where(p => !p.Deleted);


            if (filter.Equals(default))
            {
                return await query.ToListAsync();
            }

            if (!string.IsNullOrWhiteSpace(filter.Price))
            {
                var priceRange = filter.Price.Split('-');
                if (priceRange.Length == 2)
                {
                    if (!string.IsNullOrWhiteSpace(priceRange[0]) && int.TryParse(priceRange[0], out var minPrice)) {
                        query = query.Where(p => p.Price >= minPrice);
                    }
                    
                    if (!string.IsNullOrWhiteSpace(priceRange[1]) && int.TryParse(priceRange[1], out var maxPrice)) {
                        query = query.Where(p => p.Price <= maxPrice);
                    }
                }
            }

            if (filter.ManufacturerIds != null && filter.ManufacturerIds.Any())
            {
                foreach (var manufacturerId in filter.ManufacturerIds)
                {
                    query = query
                                .Include(p => p.ProductManufacturerMapping)
                                .Where(p => p.ProductManufacturerMapping.Any(m => m.ManufacturerId == manufacturerId));
                }
            }

            if (filter.SpecificationOptionIds != null && filter.SpecificationOptionIds.Any())
            {
                query = query
                    .Where(p => p.ProductSpecificationattributeMapping.Any(psa => filter.SpecificationOptionIds.Contains(psa.SpecificationAttributeOptionId)));
            }

            if (!string.IsNullOrWhiteSpace(filter.OrderBy))
            {
                var orderBy = filter.OrderBy.ToLowerInvariant();
                var orderByAscending = filter.OrderByAscending ?? true;

                switch (orderBy)
                {
                    // case "name":
                    //     query = orderByAscending ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name);
                    //     break;
                    // case "createdonutc":
                    //     query = orderByAscending ? query.OrderBy(p => p.CreatedOnUtc) : query.OrderByDescending(p => p.CreatedOnUtc);
                    //     break;
                    // case "updatedonutc":
                    //     query = orderByAscending ? query.OrderBy(p => p.UpdatedOnUtc) : query.OrderByDescending(p => p.UpdatedOnUtc);
                    //     break;
                    // case "displayorder":
                    //     query = orderByAscending ? query.OrderBy(p => p.DisplayOrder) : query.OrderByDescending(p => p.DisplayOrder);
                    //     break;
                    // case "id":
                    //     query = orderByAscending ? query.OrderBy(p => p.Id) : query.OrderByDescending(p => p.Id);
                    //     break;
                    default: // only price is supported for now
                        query = orderByAscending ? query.OrderBy(p => p.Price) : query.OrderByDescending(p => p.Price);
                        break;
                }
            }

            return await query.ToListAsync();
        }

    }
}
