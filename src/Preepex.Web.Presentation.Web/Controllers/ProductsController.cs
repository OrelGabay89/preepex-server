using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Preepex.Common.Paging;
using Preepex.Core.Application.Attributes;
using Preepex.Core.Application.Dtos;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Factories;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Application.Interfaces.Shared.Catalog;
using Preepex.Core.Domain.Entities.ApplicationEntities;
using Preepex.Presentation.Framework.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Preepex.Common.Extensions;

namespace Preepex.Web.Presentation.Web.Controllers
{
    [Route("api/products")]
    [AutoValidateAntiforgeryToken]
    public class ProductsController : BaseApiController
    {
        private readonly ILogger<ProductsController> _logger;

        private readonly IProductModelFactory _productModelFactory;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IProductService _productService;
        private readonly IOrderReportService _orderReportService;
        private readonly IProductTagService _productTagService;
        private readonly IStoreContext _storeContext;

        public ProductsController(
            IProductModelFactory productModelFactory,
            IUrlRecordService urlRecordService,
            IProductService productService,
            IOrderReportService orderReportService,
            IProductTagService productTagService,
            IStoreContext storeContext,
            ILogger<ProductsController> logger
            )
        {
            _productModelFactory = productModelFactory;
            _urlRecordService = urlRecordService;
            _productService = productService;
            _orderReportService = orderReportService;
            _productTagService = productTagService;
            _storeContext = storeContext;
            _logger = logger;
        }


        [HttpGet("alive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Alive()
        {
            return Ok("I'm alive!");
        }

        [HttpGet("brands")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productService.GetProductBrands());
        }


        [HttpGet("new-products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Cached(600)]
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> GetNewAddedProducts()
        {
            var store = await _storeContext.GetCurrentStoreAsync();
            var products = await _productService.NewProducts(store.Id);
            return Ok(await _productModelFactory.PrepareProductsModelAsync(products));
        }

        [HttpGet("special-products")]
        [Cached(600)]
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> GetSpecialProducts()
        {
            var store = await _storeContext.GetCurrentStoreAsync();
            var products = await _productService.SpecialProducts(store.Id);
            return Ok(await _productModelFactory.PrepareProductsModelAsync(products));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Cached(600)]
        public async Task<ActionResult<Pagination<ProductDetailsDto>>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product != null)
            {
                ProductDetailsDto productDetailDto = new ProductDetailsDto();
                var model = await _productModelFactory.PrepareProductModelAsync(productDetailDto, product);
                return Ok(model);
            }

            return NotFound("Product not found");
        }

        [HttpGet("related-products/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Cached(600)]
        public async Task<ActionResult<List<ProductDetailsDto>>> GetRelatedProducts(int id)
        {
            var result = new List<ProductDetailsDto>();
            var relatedProducts = await _productService.GetRelatedProductsByProductIdAsync(id);
            foreach (var related in relatedProducts)
            {
                ProductDetailsDto productDetailDto = new ProductDetailsDto();
                var product = await _productService.GetProductByIdAsync(related.ProductId2);
                if (product != null)
                {
                    var model = await _productModelFactory.PrepareProductModelAsync(productDetailDto, product);
                    result.Add(model);
                }
            }

            return Ok(result);
        }

        [HttpGet("top-collection")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Cached(600)]
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> TopCollections()
        {
            var store = await _storeContext.GetCurrentStoreAsync();
            var products = await _productService.TopCollections(store.Id);
            return Ok(await _productModelFactory.PrepareProductsModelAsync(products));
        }

        [HttpGet("onsale")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Cached(600)]
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> OnSaleProducts()
        {
            var store = await _storeContext.GetCurrentStoreAsync();
            var products = await _productService.OnSaleProducts(store.Id);
            return Ok(await _productModelFactory.PrepareProductsModelAsync(products));
        }

        [HttpGet("best-seller")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Cached(600)]
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> BestSellerProducts()
        {
            var store = await _storeContext.GetCurrentStoreAsync();
            var products = await _orderReportService.BestSellersReportAsync(storeId: store.Id);
            var result = new List<ProductDetailsDto>();

            foreach (var bestSeller in products.Results)
            {
                ProductDetailsDto productDetailDto = new ProductDetailsDto();
                var product = await _productService.GetProductByIdAsync(bestSeller.ProductId);
                if (product != null)
                {
                    var model = await _productModelFactory.PrepareProductModelAsync(productDetailDto, product);
                    result.Add(model);
                }
            }

            return Ok(result);
        }

        [HttpGet("featured-products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        [Cached(600)]
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> FeaturedProducts()
        {
            var productsId = await _productTagService.GetProductIdsByTagNameAsync("featured");
            List<ProductDetailsDto> result = new List<ProductDetailsDto>();
            foreach (var item in productsId)
            {
                ProductDetailsDto productDetailDto = new ProductDetailsDto();
                var product = await _productService.GetProductByIdAsync(item);
                if (product != null)
                {
                    var model = await _productModelFactory.PrepareProductModelAsync(productDetailDto, product);
                    result.Add(model);
                }
            }

            return Ok(result);
        }
    }
}