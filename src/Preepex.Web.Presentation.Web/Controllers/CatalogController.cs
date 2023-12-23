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
using Microsoft.AspNetCore.Authorization;

namespace Preepex.Web.Presentation.Web.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : BasePublicController
    {
        private readonly CatalogSettings _catalogSettings;
        private readonly IProductModelFactory _productModelFactory;
        private readonly ICatalogModelFactory _catalogModelFactory;
        private readonly IProductService _productService;
        private readonly IStoreContext _storeContext;
        private readonly ICategoryService _categoryService;
        private readonly IWorkContext _workContext;
        private readonly ILogger<CatalogController> _logger;



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

        /// <summary>
        /// Get all the products
        /// </summary>
        /// <param name="term">Keyword to searh upon</param>
        /// <returns></returns>
        [HttpGet("search-products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [RedisCached(600)]
        public async Task<ActionResult<IReadOnlyList<Product>>> SearchProducts(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return BadRequest();

            term = term.Trim();

            if (string.IsNullOrWhiteSpace(term) || term.Length < _catalogSettings.ProductSearchTermMinimumLength)
                return BadRequest($"Minimum length should be {_catalogSettings.ProductSearchTermMinimumLength}");


            var productNumber = _catalogSettings.ProductSearchAutoCompleteNumberOfProducts > 0
                ? _catalogSettings.ProductSearchAutoCompleteNumberOfProducts
                : 10;
            
            var store = await _storeContext.GetCurrentStoreAsync();

            var products = await _productService.SearchProductsAsync(
                0,
                storeId: store.Id,
                keywords: term,
                languageId: (await _workContext.GetWorkingLanguageAsync()).Id,
                visibleIndividuallyOnly: true,
                pageSize: productNumber
            );

            var showLinkToResultSearch = _catalogSettings.ShowLinkToAllResultInSearchAutoComplete &&
                                         (products.TotalCount > productNumber);


            var models = (await _productModelFactory.PrepareProductOverviewModelsAsync(products, true, true, null))
                .ToList();
            
            var result = (from p in models
                    select new
                    {
                        label = p.Name,
                        seName = $"/{p?.SeName}",
                        productpictureurl = p?.PictureModel?.ThumbImageUrl,
                        showlinktoresultsearch = showLinkToResultSearch,
                        shortDesc = p?.ShortDescription,
                        sku = p.Sku,
                        ProductPriceDto = p?.ProductPrice,
                        id = p?.ProductId
                    })
                .ToList();
            return Ok(result);
        }


        [HttpPost("category-products/{categoryId}")]
        [RedisCached(600)]
        public virtual async Task<CatalogProductsResponse> GetCategoryProducts(int categoryId, [FromQuery] CatalogProductsFilter filter)
        {
            try
            {
                var (products, minPrice, maxPrice) = await _categoryService.GetProductsByCategory(categoryId, filter);
                
                var mappedProducts = await _productModelFactory.PrepareProductsModelAsync(products);

                return new CatalogProductsResponse
                {
                    products = mappedProducts,
                    filter = new CatalogProductsFilterResponse
                    {
                        minPrice = minPrice,
                        maxPrice = maxPrice
                    }
                };
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error getting category products");
                throw;
            }
            
        }
    }
}
