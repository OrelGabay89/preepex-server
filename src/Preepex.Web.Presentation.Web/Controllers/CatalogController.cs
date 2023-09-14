using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Factories;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Application.Interfaces.Shared.Catalog;
using Preepex.Core.Application.Models;
using Preepex.Core.Domain.Entities;
using Preepex.Core.Domain.Entities.Catalog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Preepex.Core.Application.Attributes;
using Preepex.Core.Application.Dtos;

namespace Preepex.Web.Presentation.Web.Controllers
{
    //[Route("api/catalog")]
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : BasePublicController
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly IProductModelFactory _productModelFactory;
        private readonly ICatalogModelFactory _catalogModelFactory;
        private readonly IProductService _productService;
        private readonly IStoreContext _storeContext;
        private readonly ICategoryService _categoryService;
        private readonly IWorkContext _workContext;
        private readonly ILogger<CatalogController> _logger;

        #endregion

        #region Ctor

        public CatalogController(
            CatalogSettings catalogSettings,
            ILocalizationService localizationService,
            IWorkContext workContext,
            IProductModelFactory productModelFactory,
            ICatalogModelFactory catalogModelFactory,
            IProductService productService,
            ICategoryService categoryService,
            IStoreContext storeContext,
            ILogger<CatalogController> logger
        ) {
            _catalogSettings = catalogSettings;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _storeContext = storeContext;
            _workContext = workContext;
            _categoryService = categoryService;
            _catalogModelFactory = catalogModelFactory;
            _logger = logger;
        }

        #endregion

        #region Searching

        [HttpGet("{categoryId}")]
        public virtual async Task<CategoryModel> Category(int categoryId)
        {
            var category = await _categoryService.GetCategoryByIdAsync(categoryId);

            //if (!await _categoryService.CheckCategoryAvailabilityAsync(category))
            //    return InvokeHttp404();


            //'Continue shopping' URL
            //await _genericAttributeService.SaveAttributeAsync(await _workContext.GetCurrentCustomerAsync(),
            //    PreepexCustomerDefaults.LastContinueShoppingPageAttribute,
            //    _webHelper.GetThisPageUrl(false),
            //    store.Id);

            ////display "edit" (manage) link
            //if (await _permissionService.AuthorizeAsync(StandardPermissionProvider.AccessAdminPanel) && await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
            //    DisplayEditLink(Url.Action("Edit", "Category", new { id = category.Id, area = AreaNames.Admin }));

            //activity log
            //await _customerActivityService.InsertActivityAsync("PublicStore.ViewCategory",
            //    string.Format(await _localizationService.GetResourceAsync("ActivityLog.PublicStore.ViewCategory"), category.Name), category);

            //model
            var model = await _catalogModelFactory.PrepareCategoryModelAsync(category);

            return model;
            ////template
            //var templateViewPath = await _catalogModelFactory.PrepareCategoryTemplateViewPathAsync(category.CategoryTemplateId);
            //return View(templateViewPath, model);
        }

//[HttpPost("category-products/id")]

        //public virtual async Task<CategoryModel> GetCategoryProducts(int categoryId, CatalogProductsCommand command)
        //{
        //    var category = await _categoryService.GetCategoryByIdAsync(categoryId);

        //    //if (!await CheckCategoryAvailabilityAsync(category))
        //    //    return NotFound();

        //    var model = await _catalogModelFactory.PrepareCategoryModelAsync(category, null);

        //    return model;
        //}
        /// <summary>
        /// Get all the products
        /// </summary>
        /// <param name="term">Keyword to searh upon</param>
        /// <returns></returns>
        [HttpGet("search-products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IReadOnlyList<Product>>> SearchProducts(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return BadRequest();

            term = term.Trim();

            if (string.IsNullOrWhiteSpace(term) || term.Length < _catalogSettings.ProductSearchTermMinimumLength)
                return BadRequest($"Minimum length should be {_catalogSettings.ProductSearchTermMinimumLength}");

            //products
            //Getting it through the const instead of CatalogSettings
            var productNumber = _catalogSettings.ProductSearchAutoCompleteNumberOfProducts > 0
                ? _catalogSettings.ProductSearchAutoCompleteNumberOfProducts
                : 10;
            var store = await _storeContext.GetCurrentStoreAsync();

            var products = await _productService.SearchProductsAsync(0,
                storeId: store.Id,
                keywords: term,
                languageId: (await _workContext.GetWorkingLanguageAsync()).Id,
                visibleIndividuallyOnly: true,
                pageSize: productNumber);

            var showLinkToResultSearch = _catalogSettings.ShowLinkToAllResultInSearchAutoComplete &&
                                         (products.TotalCount > productNumber);


            var models = (await _productModelFactory.PrepareProductOverviewModelsAsync(products, true, true, null))
                .ToList(); //_mediaSettings.AutoCompleteSearchThumbPictureSize_catalogSettings.ShowProductImagesInSearchAutoComplete
            var result = (from p in models
                    select new
                    {
                        label = p.Name,
                        producturl = $"/{p?.SeName}",
                        productpictureurl = p?.PictureModel?.ThumbImageUrl,
                        showlinktoresultsearch = showLinkToResultSearch,
                        shortDesc = p?.ShortDescription,
                        sku = p.Sku,
                        ProductPriceDto = p?.ProductPrice
                    })
                .ToList();
            return Ok(result);
        }


        [HttpPost("category-products/{categoryId}")]
        [Cached(600)]
        public virtual async Task<IReadOnlyList<ProductDetailsDto>> GetCategoryProducts(int categoryId, [FromBody] CatalogProductsCommand command)
        {
            try
            {
                var products = await _categoryService.GetProductsByCategory(categoryId, command);
                
                return await _productModelFactory.PrepareProductsModelAsync(products);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error getting category products");
                throw;
            }
            
        }

        #endregion
    }
}
