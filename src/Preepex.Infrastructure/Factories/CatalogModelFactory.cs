using Microsoft.Extensions.Configuration;
using Preepex.Core.Application.Caching;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Factories;
using Preepex.Core.Application.Interfaces.Security;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Application.Interfaces.Shared.Catalog;
using Preepex.Core.Application.Interfaces.Shared.Customers;
using Preepex.Core.Application.Media;
using Preepex.Core.Application.Models;
using Preepex.Core.Domain.Entities;
using Preepex.Core.Domain.Entities.Catalog;
using Preepex.Core.Domain.Entities.Common;
using Preepex.Core.Domain.Entities.Media;
using Preepex.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Factories
{
    public class CatalogModelFactory : ICatalogModelFactory
    {
        private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;
        private readonly IProductModelFactory _productModelFactory;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly ITopicService _topicService;
        private readonly ICategoryService _categoryService;
        private readonly ILocalizationService _localizationService;
        private readonly IPictureService _pictureService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IAclService _aclService;

        private readonly MediaSettings _mediaSettings;
        private readonly DisplayDefaultMenuItemSettings _displayDefaultMenuItemSettings;
        private readonly CatalogSettings _catalogSettings;

        private readonly IStaticCacheManager _staticCacheManager;

        private readonly IWebHelper _webHelper;
        private readonly string NopUrl;

        public CatalogModelFactory(IWorkContext workContext, IStoreContext storeContext, MediaSettings mediaSettings
            , DisplayDefaultMenuItemSettings displayDefaultMenuItemSettings, CatalogSettings catalogSettings
            , IStaticCacheManager staticCacheManager, ICategoryService categoryService, ICustomerService customerService
            , ILocalizationService localizationService, ITopicService topicService, IPictureService pictureService
            , IUrlRecordService urlRecordService, IProductService productService, IStoreMappingService storeMappingService
            , IAclService aclService, IProductModelFactory productModelFactory
            , IConfiguration config, IWebHelper webHelper
            )
        {
            _workContext = workContext;
            _storeContext = storeContext;
            _mediaSettings = mediaSettings;
            _staticCacheManager = staticCacheManager;

            _customerService = customerService;
            _categoryService = categoryService;
            _localizationService = localizationService;
            _pictureService = pictureService;
            _urlRecordService = urlRecordService;
            _topicService = topicService;
            _storeMappingService = storeMappingService;
            _aclService = aclService;

            _webHelper = webHelper;
            _displayDefaultMenuItemSettings = displayDefaultMenuItemSettings;
            _catalogSettings = catalogSettings;

        }

        /// <summary>
        /// Prepare homepage category models
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the list of homepage category models
        /// </returns>
        public virtual async Task<List<CategoryModel>> PrepareHomepageCategoryModelsAsync(int storeId)
        {
            var language = await _workContext.GetWorkingLanguageAsync();
            var customer = await _workContext.GetCurrentCustomerAsync();
            var customerRoleIds = await _customerService.GetCustomerRoleIdsAsync(customer);
            var store = await _storeContext.GetCurrentStoreAsync();
            var pictureSize = _mediaSettings.CategoryThumbPictureSize;
            var categoriesCacheKey = _staticCacheManager.PrepareKeyForDefaultCache(PreepexModelCacheDefaults.CategoryHomepageKey,
                store, customerRoleIds, pictureSize, language, _webHelper.IsCurrentConnectionSecured());
            var model = await _staticCacheManager.GetAsync(categoriesCacheKey, async () =>
            {
                var homepageCategories = await _categoryService.GetAllCategoriesDisplayedOnHomepageAsync(storeId);
                var categorySlugs = await _urlRecordService.GetSeNamesAsync(homepageCategories.ToArray());

                return await homepageCategories.SelectAwait(async category =>
                {

                    var categorySlug = "";

                    var defaultKey = default(KeyValuePair<Tuple<string, string, int>, string>);

                    var categorySlugFound = categorySlugs.FirstOrDefault(x => x.Key.Item1 == category.Id.ToString() && x.Key.Item2 == "Category");

                    if (!categorySlugFound.Equals(defaultKey))
                    {
                        categorySlug = categorySlugFound.Value;
                    }

                    var name = await _localizationService.GetLocalizedAsync(category, x => x.Name);
                    var description = await _localizationService.GetLocalizedAsync(category, x => x.Description);
                    var metaKeywords = await _localizationService.GetLocalizedAsync(category, x => x.MetaKeywords);
                    var metaDescription = await _localizationService.GetLocalizedAsync(category, x => x.MetaDescription);
                    var metaTitle = await _localizationService.GetLocalizedAsync(category, x => x.MetaTitle);

                    var catModel = new CategoryModel
                    {
                        Id = category.Id,
                        Name = name,
                        Description = description,
                        MetaKeywords = metaKeywords,
                        MetaDescription = metaDescription,
                        MetaTitle = metaTitle,
                        SeName = categorySlug,
                    };

                    //prepare picture model
                    var secured = _webHelper.IsCurrentConnectionSecured();
                    var categoryPictureCacheKey = _staticCacheManager.PrepareKeyForDefaultCache(PreepexModelCacheDefaults.CategoryPictureModelKey,
                        category, pictureSize, true, language, secured, store);
                    catModel.PictureModel = await _staticCacheManager.GetAsync(categoryPictureCacheKey, async () =>
                    {
                        var picture = await _pictureService.GetPictureByIdAsync(category.PictureId);
                        string fullSizeImageUrl, imageUrl;

                        (fullSizeImageUrl, picture) = await _pictureService.GetPictureUrlAsync(picture);
                        (imageUrl, _) = await _pictureService.GetPictureUrlAsync(picture, pictureSize);

                        var titleLocale = await _localizationService.GetResourceAsync("Media.Category.ImageLinkTitleFormat");
                        var altLocale = await _localizationService.GetResourceAsync("Media.Category.ImageAlternateTextFormat");
                        return new PictureModel
                        {
                            FullSizeImageUrl = $"{fullSizeImageUrl}",
                            ImageUrl = $"{imageUrl}",
                            Title = string.Format(titleLocale, catModel.Name),
                            AlternateText = string.Format(altLocale, catModel.Name)
                        };
                    });

                    return catModel;
                }).ToListAsync();
            });

            return model;
        }

        /// <summary>
        /// Prepare top menu model
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the op menu model
        /// </returns>
        public virtual async Task<TopMenuModel> PrepareTopMenuModelAsync()
        {

            var cachedCategoriesModel = await PrepareCategorySimpleModelsAsync();

            var store = await _storeContext.GetCurrentStoreAsync();

            //top menu topics
            //var topicModel = await (await _topicService.GetAllTopicsAsync(store.Id, onlyIncludedInTopMenu: true))
            //    .SelectAwait(async t => new TopMenuModel.TopicModel
            //    {
            //        Id = t.Id,
            //        Name = await _localizationService.GetLocalizedAsync(t, x => x.Title),
            //        seName = await _urlRecordService.GetSeNameAsync(t)
            //    }).ToListAsync();

            var model = new TopMenuModel
            {
                Categories = cachedCategoriesModel,
                //Topics = topicModel,
                NewProductsEnabled = _catalogSettings.NewProductsEnabled,
                //BlogEnabled = _blogSettings.Enabled,
                //ForumEnabled = _forumSettings.ForumsEnabled,
                DisplayHomepageMenuItem = _displayDefaultMenuItemSettings.DisplayHomepageMenuItem,
                DisplayNewProductsMenuItem = _displayDefaultMenuItemSettings.DisplayNewProductsMenuItem,
                DisplayProductSearchMenuItem = _displayDefaultMenuItemSettings.DisplayProductSearchMenuItem,
                DisplayCustomerInfoMenuItem = _displayDefaultMenuItemSettings.DisplayCustomerInfoMenuItem,
                DisplayBlogMenuItem = _displayDefaultMenuItemSettings.DisplayBlogMenuItem,
                DisplayForumsMenuItem = _displayDefaultMenuItemSettings.DisplayForumsMenuItem,
                DisplayContactUsMenuItem = _displayDefaultMenuItemSettings.DisplayContactUsMenuItem,
            };

            return model;
        }

        /// <summary>
        /// Prepare category (simple) models
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the list of category (simple) models
        /// </returns>
        public virtual async Task<List<CategorySimpleModel>> PrepareCategorySimpleModelsAsync()
        {
            //load and cache them
            var language = await _workContext.GetWorkingLanguageAsync();
            var customer = await _workContext.GetCurrentCustomerAsync();
            var customerRoleIds = await _customerService.GetCustomerRoleIdsAsync(customer);
            var store = await _storeContext.GetCurrentStoreAsync();
            var cacheKey = _staticCacheManager.PrepareKeyForDefaultCache(PreepexModelCacheDefaults.CategoryAllModelKey,
                language, customerRoleIds, store);

            return await _staticCacheManager.GetAsync(cacheKey, async () => await PrepareCategorySimpleModelsAsync(0));
        }

        /// <summary>
        /// Prepare category (simple) models
        /// </summary>
        /// <param name="rootCategoryId">Root category identifier</param>
        /// <param name="loadSubCategories">A value indicating whether subcategories should be loaded</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the list of category (simple) models
        /// </returns>
        /// 
        //public virtual async Task<List<CategorySimpleModel>> PrepareCategorySimpleModelsAsync(int rootCategoryId, bool loadSubCategories = true)
        //{
        //    var store = await _storeContext.GetCurrentStoreAsync();
        //    var categories = await _categoryService.GetAllCategoriesAsync(storeId: store.Id);

        //    if (categories == null || !categories.Any())
        //    {
        //        return new List<CategorySimpleModel>();
        //    }

        //    var result = await categories.Select(async category =>
        //    {
        //        var categoryModel = new CategorySimpleModel
        //        {
        //            Id = category.Id,
        //            Name = await _localizationService.GetLocalizedAsync(category, x => x.Name),
        //            seName = await _urlRecordService.GetSeNameAsync(category),
        //            IncludeInTopMenu = category.IncludeInTopMenu
        //        };

        //        if (loadSubCategories)
        //        {
        //            var subCategories = await PrepareCategorySimpleModelsAsync(category.Id);
        //            categoryModel.SubCategories.AddRange(subCategories);
        //        }

        //        categoryModel.HaveSubCategories = categoryModel.SubCategories.Count > 0 &&
        //            categoryModel.SubCategories.Any(x => x.IncludeInTopMenu);

        //        return categoryModel;
        //    }).ToListAsync();

        //    return result;
        //}

        public virtual async Task<List<CategorySimpleModel>> PrepareCategorySimpleModelsAsync(int rootCategoryId, bool loadSubCategories = true)
        {
            var result = new List<CategorySimpleModel>();

            //little hack for performance optimization
            //we know that this method is used to load top and left menu for categories.
            //it'll load all categories anyway.
            //so there's no need to invoke "GetAllCategoriesByParentCategoryId" multiple times (extra SQL commands) to load childs
            //so we load all categories at once (we know they are cached)
            var store = await _storeContext.GetCurrentStoreAsync();
            var allCategories = await _categoryService.GetAllCategoriesAsync(storeId: store.Id);
            var categories = allCategories.Where(c => c.ParentCategoryId == rootCategoryId).OrderBy(c => c.DisplayOrder).ToList();

            var categorySlugs = await _urlRecordService.GetSeNamesAsync(categories.ToArray());

            foreach (var category in categories)
            {
                var categorySlug = "";

                var defaultKey = default(KeyValuePair<Tuple<string, string, int>, string>);
                var categorySlugFound = categorySlugs.FirstOrDefault(x => x.Key.Item1 == category.Id.ToString() && x.Key.Item2 == "Category");

                if (!categorySlugFound.Equals(defaultKey))
                {
                    categorySlug = categorySlugFound.Value;
                }

                var categoryModel = new CategorySimpleModel
                {
                    Id = category.Id,
                    Name = await _localizationService.GetLocalizedAsync(category, x => x.Name),
                    SeName = categorySlug,
                    IncludeInTopMenu = category.IncludeInTopMenu
                };

                //number of products in each category
                //if (_catalogSettings.ShowCategoryProductNumber)
                //{
                //    var categoryIds = new List<int> { category.Id };
                //    //include subcategories
                //    if (_catalogSettings.ShowCategoryProductNumberIncludingSubcategories)
                //        categoryIds.AddRange(
                //            await _categoryService.GetChildCategoryIdsAsync(category.Id, store.Id));

                //    categoryModel.NumberOfProducts =
                //        await _productService.GetNumberOfProductsInCategoryAsync(categoryIds, store.Id);
                //}

                //if (loadSubCategories)
                //{
                //    var subCategories = await PrepareCategorySimpleModelsAsync(category.Id);
                //    categoryModel.SubCategories.AddRange(subCategories);
                //}

                categoryModel.HaveSubCategories = categoryModel.SubCategories.Count > 0 &
                    categoryModel.SubCategories.Any(x => x.IncludeInTopMenu);

                result.Add(categoryModel);
            }

            return result;
        }


        /// <summary>
        /// Prepare category model
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="command">Model to get the catalog products</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the category model
        /// </returns>
        public virtual async Task<CategoryModel> PrepareCategoryModelAsync(Category category, CatalogProductsCommand command = null)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            //if (command == null)
            //    throw new ArgumentNullException(nameof(command));

            var model = new CategoryModel
            {
                Id = category.Id,
                Name = await _localizationService.GetLocalizedAsync(category, x => x.Name),
                Description = await _localizationService.GetLocalizedAsync(category, x => x.Description),
                MetaKeywords = await _localizationService.GetLocalizedAsync(category, x => x.MetaKeywords),
                MetaDescription = await _localizationService.GetLocalizedAsync(category, x => x.MetaDescription),
                MetaTitle = await _localizationService.GetLocalizedAsync(category, x => x.MetaTitle),
                SeName = await _urlRecordService.GetSeNameAsync(category),
                //CatalogProductsModel = await PrepareCategoryProductsModelAsync(category, command)
            };

            //category breadcrumb
            if (_catalogSettings.CategoryBreadcrumbEnabled)
            {
                model.DisplayCategoryBreadcrumb = true;

                model.CategoryBreadcrumb = await (await _categoryService.GetCategoryBreadCrumbAsync(category)).SelectAwait(async catBr =>
                    new CategoryModel
                    {
                        Id = catBr.Id,
                        Name = await _localizationService.GetLocalizedAsync(catBr, x => x.Name),
                        SeName = await _urlRecordService.GetSeNameAsync(catBr)
                    }).ToListAsync();
            }

            var currentStore = await _storeContext.GetCurrentStoreAsync();
            var pictureSize = _mediaSettings.CategoryThumbPictureSize;

            //subcategories
            model.SubCategories = await (await _categoryService.GetAllCategoriesByParentCategoryIdAsync(category.Id))
                .SelectAwait(async curCategory =>
                {
                    var subCatModel = new CategoryModel.SubCategoryModel
                    {
                        Id = curCategory.Id,
                        Name = await _localizationService.GetLocalizedAsync(curCategory, y => y.Name),
                        SeName = await _urlRecordService.GetSeNameAsync(curCategory),
                        Description = await _localizationService.GetLocalizedAsync(curCategory, y => y.Description)
                    };

                    //prepare picture model
                    var categoryPictureCacheKey = _staticCacheManager.PrepareKeyForDefaultCache(PreepexModelCacheDefaults.CategoryPictureModelKey, curCategory,
                        pictureSize, true, await _workContext.GetWorkingLanguageAsync(), _webHelper.IsCurrentConnectionSecured(),
                        currentStore);

                    subCatModel.PictureModel = await _staticCacheManager.GetAsync(categoryPictureCacheKey, async () =>
                    {
                        var picture = await _pictureService.GetPictureByIdAsync(curCategory.PictureId);
                        string fullSizeImageUrl, imageUrl;

                        (fullSizeImageUrl, picture) = await _pictureService.GetPictureUrlAsync(picture);
                        (imageUrl, _) = await _pictureService.GetPictureUrlAsync(picture, pictureSize);

                        var pictureModel = new PictureModel
                        {
                            FullSizeImageUrl = fullSizeImageUrl,
                            ImageUrl = imageUrl,
                            Title = string.Format(await _localizationService
                                .GetResourceAsync("Media.Category.ImageLinkTitleFormat"), subCatModel.Name),
                            AlternateText = string.Format(await _localizationService
                                .GetResourceAsync("Media.Category.ImageAlternateTextFormat"), subCatModel.Name)
                        };

                        return pictureModel;
                    });

                    return subCatModel;
                }).ToListAsync();

            //featured products
            //if (!_catalogSettings.IgnoreFeaturedProducts)
            //{
            //    var featuredProducts = await _productService.GetCategoryFeaturedProductsAsync(category.Id, currentStore.Id);
            //    if (featuredProducts != null)
            //        model.FeaturedProducts = (await _productModelFactory.PrepareProductOverviewModelsAsync(featuredProducts)).ToList();
            //}

            return model;
        }


    }
}
