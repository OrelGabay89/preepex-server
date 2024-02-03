using AutoMapper;
using Microsoft.Extensions.Configuration;
using Preepex.Common.Paging;
using Preepex.Core.Application.Caching;
using Preepex.Core.Application.Dtos;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Factories;
using Preepex.Core.Application.Interfaces.Security;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Application.Interfaces.Shared.Catalog;
using Preepex.Core.Application.Interfaces.Shared.Shipping;
using Preepex.Core.Application.Interfaces.Shared.Tax;
using Preepex.Core.Application.Media;
using Preepex.Core.Application.Models;
using Preepex.Core.Domain.Entities;
using Preepex.Core.Domain.Entities.Catalog;
using Preepex.Core.Domain.Entities.Media;
using Preepex.Core.Domain.Enumerations;
using Preepex.Core.Domain.NopEntities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Preepex.Common.Extensions;
using Preepex.Core.Application.Extensions;

namespace Preepex.Infrastructure.Factories
{
    public class ProductModelFactory : IProductModelFactory
    {
        #region declaration

        private readonly ILocalizationService _localizationService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IPictureService _pictureService;
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly IPriceCalculationService _priceCalculationService;
        private readonly ICurrencyService _currencyService;
        private readonly IProductService _productService;
        private readonly IProductTagService _productTagService;
        private readonly IVendorService _vendorService;
        private readonly IProductAttributeService _productAttributeService;
        private readonly ITaxService _taxService;
        private readonly IDateRangeService _dateRangeService;

        private readonly MediaSettings _mediaSettings;
        private readonly CatalogSettings _catalogSettings;
        private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;
        private readonly IMapper _mapper;
        private readonly IPriceFormatter _priceFormatter;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public ProductModelFactory(ILocalizationService localizationService, IUrlRecordService urlRecordService,
            IStoreContext storeContext,
            IPictureService pictureService,
            ISpecificationAttributeService specificationAttributeService,
            IPriceCalculationService priceCalculationService, ICurrencyService currencyService,
            IProductService productService,
            IProductTagService productTagService,
            IVendorService vendorService,
            IProductAttributeService productAttributeService,
            IAclService aclService,
            IDateRangeService dateRangeService,
            IWorkContext workContext,
            ITaxService taxService,
            IPriceFormatter priceFormatter,
            IMapper mapper,
            IConfiguration config,
            IStaticCacheManager staticCacheManager,
            IWebHelper webHelper,
            MediaSettings mediaSettings,
            CatalogSettings catalogSettings
        )
        {
            _localizationService = localizationService;
            _urlRecordService = urlRecordService;
            _storeContext = storeContext;
            _pictureService = pictureService;
            _specificationAttributeService = specificationAttributeService;
            _priceCalculationService = priceCalculationService;
            _currencyService = currencyService;
            _productService = productService;
            _productTagService = productTagService;
            _vendorService = vendorService;
            _productAttributeService = productAttributeService;
            _mediaSettings = mediaSettings;
            _catalogSettings = catalogSettings;
            _dateRangeService = dateRangeService;
            _workContext = workContext;
            _taxService = taxService;
            _priceFormatter = priceFormatter;
            _mapper = mapper;
            _staticCacheManager = staticCacheManager;
            _webHelper = webHelper;
        }

        #endregion

        #region Methods

        public virtual async Task<IReadOnlyList<ProductDetailsDto>> PrepareProductsModelAsync(
            IEnumerable<Product> products)
        {
            var result = new List<ProductDetailsDto>();

            var currency = (await _workContext.GetWorkingCurrencyAsync()).CurrencyCode;

            // First, get all picture models in a batch
            var productsList = products.ToList();
            
            var allPictureModels = await PrepareProductDetailsPictureModelsAsync(productsList, false);

            foreach (var item in productsList)
            {
                var product = new ProductDetailsDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    FullDescription = item.ShortDescription,
                    Sku = item.Sku,
                    ProductPrice = new ProductDetailsDto.ProductPriceModel
                    {
                        CurrencyCode = currency,
                        OldPrice = item.OldPrice.ToString(CultureInfo.InvariantCulture),
                        CallForPrice = item.CallForPrice,
                        Price = item.Price.ToString(CultureInfo.InvariantCulture),
                        IsRental = item.IsRental
                    },
                    New = item.MarkAsNew,
                    Sale = item.HasDiscountsApplied,
                    SeName = await _urlRecordService.GetSeNameAsync(item)
                };

                // Use batch-loaded picture models
                if (allPictureModels.TryGetValue(item.Id, out var model))
                {
                    product.DefaultPictureModel = model.pictureModel;
                    product.PictureModels = model.allPictureModels;
                }

                result.Add(product);
            }

            return result;
        }

        /// <summary>
        /// Prepare the product overview models
        /// </summary>
        /// <param name="products">Collection of products</param>
        /// <param name="preparePriceModel">Whether to prepare the price model</param>
        /// <param name="preparePictureModel">Whether to prepare the picture model</param>
        /// <param name="productThumbPictureSize">Product thumb picture size (longest side); pass null to use the default value of media settings</param>
        /// <param name="prepareSpecificationAttributes">Whether to prepare the specification attribute models</param>
        /// <param name="forceRedirectionAfterAddingToCart">Whether to force redirection after adding to cart</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the collection of product overview model
        /// </returns>
        public virtual async Task<IEnumerable<ProductOverviewDto>> PrepareProductOverviewModelsAsync(
            IEnumerable<Product> products,
            bool preparePriceModel = true, bool preparePictureModel = false,
            int? productThumbPictureSize = null, bool prepareSpecificationAttributes = false,
            bool forceRedirectionAfterAddingToCart = false)
        {
            if (products == null)
                throw new ArgumentNullException(nameof(products));

            var models = new List<ProductOverviewDto>();
            foreach (var product in products)
            {
                var model = new ProductOverviewDto
                {
                    ProductId = product.Id,
                    Name = await _localizationService.GetLocalizedAsync(product, x => x.Name),
                    ShortDescription = await _localizationService.GetLocalizedAsync(product, x => x.ShortDescription),
                    FullDescription = await _localizationService.GetLocalizedAsync(product, x => x.FullDescription),
                    SeName = await _urlRecordService.GetSeNameAsync(product),
                    Sku = product.Sku,
                    //ProductType = product.ProductType,
                    MarkAsNew = product.MarkAsNew &&
                                (!product.MarkAsNewStartDateTimeUtc.HasValue ||
                                 product.MarkAsNewStartDateTimeUtc.Value < DateTime.UtcNow) &&
                                (!product.MarkAsNewEndDateTimeUtc.HasValue ||
                                 product.MarkAsNewEndDateTimeUtc.Value > DateTime.UtcNow)
                };

                //price
                if (preparePriceModel)
                {
                    model.ProductPrice =
                        await PrepareProductOverviewPriceModelAsync(product, forceRedirectionAfterAddingToCart);
                }

                //picture
                if (preparePictureModel)
                {
                    model.PictureModel = await PrepareThumbPicture(product);
                }

                //specs
                if (prepareSpecificationAttributes)
                {
                    model.ProductSpecificationModel = await PrepareProductSpecificationModelAsync(product);
                }

                //reviews
                model.ReviewOverviewModel = await PrepareProductReviewOverviewModelAsync(product);

                models.Add(model);
            }

            return models;
        }

        protected virtual async Task<PictureDto> PrepareThumbPicture(Product product)
        {
            string thumbImageUrl;
            var pictures = await _pictureService.GetPicturesByProductIdAsync(product.Id);
            var defaultPicture = pictures.FirstOrDefault();
            (thumbImageUrl, defaultPicture) =
                await _pictureService.GetPictureUrlAsync(defaultPicture, _mediaSettings.ProductThumbPictureSize, false);

            PictureDto defaultPictureModel = null;
            if (pictures.Any())
            {
                defaultPictureModel = new PictureDto
                {
                    ThumbImageUrl = $"{thumbImageUrl}"
                };
                defaultPictureModel.Title = defaultPicture.TitleAttribute;
                defaultPictureModel.AlternateText = defaultPicture.AltAttribute;
            }

            return defaultPictureModel;
        }

        public virtual async Task<ProductDetailsDto> PrepareProductModelAsync(ProductDetailsDto model, Product product,
            bool isAssociatedProduct = false)
        {
            if (!product.VisibleIndividually && !isAssociatedProduct)
            {
                //is this one an associated products?
                var parentGroupedProduct = await _productService.GetProductByIdAsync(product.ParentGroupedProductId);
                if (parentGroupedProduct == null)
                {
                    return null;
                }
                else
                {
                    product = parentGroupedProduct;
                }
            }

            model = new ProductDetailsDto
            {
                Id = product.Id,
                Name = await _localizationService.GetLocalizedAsync(product, x => x.Name),
                ShortDescription = await _localizationService.GetLocalizedAsync(product, x => x.ShortDescription),
                FullDescription = await _localizationService.GetLocalizedAsync(product, x => x.FullDescription),
                MetaKeywords = await _localizationService.GetLocalizedAsync(product, x => x.MetaKeywords),
                MetaDescription = await _localizationService.GetLocalizedAsync(product, x => x.MetaDescription),
                MetaTitle = await _localizationService.GetLocalizedAsync(product, x => x.MetaTitle),
                SeName = await _urlRecordService.GetSeNameAsync(product),
                ProductType = (ProductTypeEnum)product.ProductTypeId,
                ShowSku = _catalogSettings.ShowSkuOnProductDetailsPage,
                Sku = product.Sku,
                ShowManufacturerPartNumber = _catalogSettings.ShowManufacturerPartNumber,
                FreeShippingNotificationEnabled = _catalogSettings.ShowFreeShippingNotification,
                ManufacturerPartNumber = product.ManufacturerPartNumber,
                ShowGtin = _catalogSettings.ShowGtin,
                Gtin = product.Gtin,
                ManageInventoryMethod = (ManageInventoryMethodEnum)product.ManageInventoryMethodId,
                HasSampleDownload = product.IsDownload && product.HasSampleDownload,
                DisplayDiscontinuedMessage = !product.Published &&
                                             _catalogSettings.DisplayDiscontinuedMessageForUnpublishedProducts,
                AvailableEndDate = product.AvailableEndDateTimeUtc,
                VisibleIndividually = product.VisibleIndividually,
                AllowAddingOnlyExistingAttributeCombinations = product.AllowAddingOnlyExistingAttributeCombinations,
                IsFreeShipping = product.IsFreeShipping,
                New = product.MarkAsNew,
                Sale = product.HasDiscountsApplied,
            };

            model.ProductTags =
                _mapper.Map<List<ProductTagModel>>(
                    await _productTagService.GetAllProductTagsByProductIdAsync(product.Id));

            foreach (var item in model.ProductTags)
            {
                item.ProductCount = await _productTagService.GetProductCountByProductTagIdAsync(item.Id, storeId: 0);
            }

            switch (product.ManageInventoryMethod)
            {
                case ManageInventoryMethod.DontManageStock:
                    model.InStock = true;
                    break;

                case ManageInventoryMethod.ManageStock:
                    model.InStock = product.BackorderMode != BackorderMode.NoBackorders
                                    || await _productService.GetTotalStockQuantityAsync(product) > 0;
                    model.DisplayBackInStockSubscription = !model.InStock && product.AllowBackInStockSubscriptions;
                    break;

            }

            //shipping info
            model.IsShipEnabled = product.IsShipEnabled;
            if (product.IsShipEnabled)
            {
                model.IsFreeShipping = product.IsFreeShipping;
                //delivery date
                var deliveryDate = await _dateRangeService.GetDeliveryDateByIdAsync(product.DeliveryDateId);
                if (deliveryDate != null)
                {
                    model.DeliveryDate = await _localizationService.GetLocalizedAsync(deliveryDate, x => x.Name);
                }
            }

            var store = await _storeContext.GetCurrentStoreAsync();
            //email a friend
            model.EmailAFriendEnabled = _catalogSettings.EmailAFriendEnabled;
            //compare products
            model.CompareProductsEnabled = _catalogSettings.CompareProductsEnabled;
            //store name
            model.CurrentStoreName = await _localizationService.GetLocalizedAsync(store, x => x.Name);

            //var vendor = await _vendorService.GetVendorByIdAsync(product.VendorId);
            //if (vendor != null)
            //{
            //    model.ShowVendor = true;
            //    model.VendorModel = new VendorBriefInfoModel
            //    {
            //        Id = vendor.Id,
            //        Name = vendor.Name,
            //        SeName = await _urlRecordService.GetSeNameAsync(vendor),
            //    };
            //}

            //pictures
            model.DefaultPictureZoomEnabled = _mediaSettings.DefaultPictureZoomEnabled;
            IList<PictureModel> allPictureModels;
            (model.DefaultPictureModel, allPictureModels) =
                await PrepareProductDetailsPictureModelAsync(product, false);
            model.PictureModels = allPictureModels;
            var produtAttributes =
                await _productAttributeService.GetProductAttributeMappingsByProductIdAsync(product.Id);

            var produtAttributesModel = new List<ProductDetailsDto.ProductAttributeModel>();

            foreach (var attribute in produtAttributes)
            {
                var productAttrubute =
                    await _productAttributeService.GetProductAttributeByIdAsync(attribute.ProductAttributeId);

                var attributeModel = new ProductDetailsDto.ProductAttributeModel
                {
                    Id = attribute.Id,
                    ProductId = product.Id,
                    ProductAttributeId = attribute.ProductAttributeId,
                    Name = productAttrubute.Name,
                    Description = productAttrubute.Description,
                    TextPrompt = attribute.TextPrompt,
                    IsRequired = attribute.IsRequired,
                    AttributeControlType = (AttributeControlTypeEnum)attribute.AttributeControlTypeId,
                    DefaultValue = attribute.DefaultValue,
                    HasCondition = !string.IsNullOrEmpty(attribute.ConditionAttributeXml)
                };
                if (!string.IsNullOrEmpty(attribute.ValidationFileAllowedExtensions))
                {
                    attributeModel.AllowedFileExtensions = attribute.ValidationFileAllowedExtensions
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                }

                if (attribute.ShouldHaveValues())
                {
                    //values
                    var attributeValues = await _productAttributeService.GetProductAttributeValuesAsync(attribute.Id);
                    foreach (var attributeValue in attributeValues)
                    {
                        var valueModel = new ProductDetailsDto.ProductAttributeValueModel
                        {
                            Id = attributeValue.Id,
                            Name = attributeValue.Name,
                            ColorSquaresRgb = attributeValue.ColorSquaresRgb, //used with "Color squares" attribute type
                            IsPreSelected = attributeValue.IsPreSelected,
                            CustomerEntersQty = attributeValue.CustomerEntersQty,
                            Quantity = attributeValue.Quantity,
                            PriceAdjustment = attributeValue.PriceAdjustment.ToString(),
                            PriceAdjustmentUsePercentage = attributeValue.PriceAdjustmentUsePercentage
                        };
                        attributeModel.Values.Add(valueModel);
                        //"image square" picture (with with "image squares" attribute type only)
                        if (attributeValue.ImageSquaresPictureId > 0)
                        {
                            var imageSquaresPicture =
                                await _pictureService.GetPictureByIdAsync(attributeValue.ImageSquaresPictureId);
                            string fullSizeImageUrl, imageUrl;
                            (imageUrl, imageSquaresPicture) =
                                await _pictureService.GetPictureUrlAsync(imageSquaresPicture,
                                    _mediaSettings.ImageSquarePictureSize);
                            (fullSizeImageUrl, imageSquaresPicture) =
                                await _pictureService.GetPictureUrlAsync(imageSquaresPicture);

                            if (imageSquaresPicture != null)
                            {
                                valueModel.ImageSquaresPictureModel = new PictureModel
                                {
                                    FullSizeImageUrl = fullSizeImageUrl,
                                    ImageUrl = imageUrl
                                };
                            }
                        }

                        //picture of a product attribute value
                        valueModel.PictureId = attributeValue.PictureId;
                    }
                }

                produtAttributesModel.Add(attributeModel);
            }

            model.ProductPrice = new ProductDetailsDto.ProductPriceModel
            {
                CurrencyCode = (await _workContext.GetWorkingCurrencyAsync()).CurrencyCode,
                OldPrice = product.OldPrice.ToString(),
                CallForPrice = product.CallForPrice,
                Price = product.Price.ToString(),
                IsRental = product.IsRental
            };

            model.ProductSpecificationModel = await GetProductSpecificationModelAsync(product.Id);
            //Associated Products
            if (model.ProductType == ProductTypeEnum.GroupedProduct)
            {
                if (!isAssociatedProduct)
                {
                    var associatedProducts = await _productService.GetAssociatedProductsAsync(product.Id);
                    foreach (var associatedProduct in associatedProducts)
                    {
                        var associateProduct = await _productService.GetProductByIdAsync(associatedProduct.Id);
                        if (associateProduct != null)
                            model.AssociatedProducts.Add(_mapper.Map<ProductDetailsDto>(associateProduct));
                    }
                }
            }

            //reviews
            model.ReviewOverviewModel = await PrepareProductReviewOverviewModelAsync(product);

            return model;
        }

        public async Task<ProductSpecificationModel> GetProductSpecificationModelAsync(int productId)
        {
            if (productId == 0)
                throw new ArgumentNullException(nameof(productId));

            var model = new ProductSpecificationModel();

            // Add non-grouped attributes first
            model.Groups.Add(new Core.Application.Models.ProductSpecificationAttributeGroupModel
            {
                Attributes = await PrepareProductSpecificationAttributeModelAsync(productId, null)
            });

            // Add grouped attributes
            var groups = await _specificationAttributeService.GetProductSpecificationAttributeGroupsAsync(productId);
            foreach (var group in groups)
            {
                model.Groups.Add(new Core.Application.Models.ProductSpecificationAttributeGroupModel
                {
                    Id = group.Id,
                    Name = group.Name,
                    Attributes = await PrepareProductSpecificationAttributeModelAsync(productId, group.Id)
                });
            }

            return model;
        }

        /// <summary>
        /// Prepare the product specification model
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the product specification model
        /// </returns>
        public virtual async Task<ProductSpecificationDto> PrepareProductSpecificationModelAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var model = new ProductSpecificationDto();

            // Add non-grouped attributes first
            model.Groups.Add(new ProductSpecificationAttributeGroupModel
            {
                Attributes = await PrepareProductSpecificationAttributeModelAsync(product, null)
            });

            // Add grouped attributes
            var groups = await _specificationAttributeService.GetProductSpecificationAttributeGroupsAsync(product.Id);
            foreach (var group in groups)
            {
                model.Groups.Add(new ProductSpecificationAttributeGroupModel
                {
                    Id = group.Id,
                    Name = await _localizationService.GetLocalizedAsync(group, x => x.Name),
                    Attributes = await PrepareProductSpecificationAttributeModelAsync(product, group)
                });
            }

            return model;
        }

        #endregion

        #region Utils

        /// <summary>
        /// Prepare the product overview price model
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="forceRedirectionAfterAddingToCart">Whether to force redirection after adding to cart</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the product overview price model
        /// </returns>
        protected virtual async Task<ProductPriceDto> PrepareProductOverviewPriceModelAsync(Product product,
            bool forceRedirectionAfterAddingToCart = false)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var priceModel = new ProductPriceDto
            {
                ForceRedirectionAfterAddingToCart = forceRedirectionAfterAddingToCart
            };
            var ProductType = (ProductTypeEnum)product.ProductTypeId;

            switch (ProductType)
            {
                case ProductTypeEnum.GroupedProduct:
                    //grouped product
                    await PrepareGroupedProductOverviewPriceModelAsync(product, priceModel);

                    break;
                case ProductTypeEnum.SimpleProduct:
                default:
                    //simple product
                    await PrepareSimpleProductOverviewPriceModelAsync(product, priceModel);

                    break;
            }

            return priceModel;
        }

        protected virtual async Task PrepareSimpleProductOverviewPriceModelAsync(Product product,
            ProductPriceDto priceModel)
        {
            //rental
            priceModel.IsRental = product.IsRental;

            if (product.CustomerEntersPrice)
                return;

            if (product.CallForPrice)
            {
                //call for price
                priceModel.OldPrice = null;
                priceModel.OldPriceValue = null;
                priceModel.Price = await _localizationService.GetResourceAsync("Products.CallForPrice");
                priceModel.PriceValue = null;
            }
            else
            {
                var customer = await _workContext.GetCurrentCustomerAsync();
                var (minPossiblePriceWithoutDiscount, minPossiblePriceWithDiscount, _, _) =
                    await _priceCalculationService.GetFinalPriceAsync(product, customer);

                if (product.HasTierPrices)
                {
                    var (tierPriceMinPossiblePriceWithoutDiscount, tierPriceMinPossiblePriceWithDiscount, _, _) =
                        await _priceCalculationService.GetFinalPriceAsync(product, customer, quantity: int.MaxValue);

                    //calculate price for the maximum quantity if we have tier prices, and choose minimal
                    minPossiblePriceWithoutDiscount = Math.Min(minPossiblePriceWithoutDiscount,
                        tierPriceMinPossiblePriceWithoutDiscount);
                    minPossiblePriceWithDiscount =
                        Math.Min(minPossiblePriceWithDiscount, tierPriceMinPossiblePriceWithDiscount);
                }

                var (oldPriceBase, _) = await _taxService.GetProductPriceAsync(product, product.OldPrice);
                var (finalPriceWithoutDiscountBase, _) =
                    await _taxService.GetProductPriceAsync(product, minPossiblePriceWithoutDiscount);
                var (finalPriceWithDiscountBase, _) =
                    await _taxService.GetProductPriceAsync(product, minPossiblePriceWithDiscount);
                var currentCurrency = await _currencyService.GetCurrencyByIdAsync(1);
                var oldPrice =
                    await _currencyService.ConvertFromPrimaryStoreCurrencyAsync(oldPriceBase, currentCurrency);
                var finalPriceWithoutDiscount =
                    await _currencyService.ConvertFromPrimaryStoreCurrencyAsync(finalPriceWithoutDiscountBase,
                        currentCurrency);
                var finalPriceWithDiscount =
                    await _currencyService.ConvertFromPrimaryStoreCurrencyAsync(finalPriceWithDiscountBase,
                        currentCurrency);

                //property for German market
                //we display tax/shipping info only with "shipping enabled" for this product
                //we also ensure this it's not free shipping
                priceModel.DisplayTaxShippingInfo = _catalogSettings.DisplayTaxShippingInfoProductBoxes &&
                                                    product.IsShipEnabled && !product.IsFreeShipping;

                priceModel.Price = await _priceFormatter.FormatPriceAsync(finalPriceWithDiscount);
                priceModel.PriceValue = finalPriceWithDiscount;
            }
        }

        protected virtual async Task PrepareGroupedProductOverviewPriceModelAsync(Product product,
            ProductPriceDto priceModel)
        {
            var store = await _storeContext.GetCurrentStoreAsync();
            var associatedProducts = await _productService.GetAssociatedProductsAsync(product.Id);

            //compare products
            priceModel.DisableAddToCompareListButton = !_catalogSettings.CompareProductsEnabled;
            if (!associatedProducts.Any())
                return;


            //find a minimum possible price
            decimal? minPossiblePrice = null;
            Product minPriceProduct = null;
            var customer = await _workContext.GetCurrentCustomerAsync();
            foreach (var associatedProduct in associatedProducts)
            {
                var (_, tmpMinPossiblePrice, _, _) =
                    await _priceCalculationService.GetFinalPriceAsync(associatedProduct, customer);

                if (associatedProduct.HasTierPrices)
                {
                    //calculate price for the maximum quantity if we have tier prices, and choose minimal
                    tmpMinPossiblePrice = Math.Min(tmpMinPossiblePrice,
                        (await _priceCalculationService.GetFinalPriceAsync(associatedProduct, customer,
                            quantity: int.MaxValue)).priceWithoutDiscounts);
                }

                if (minPossiblePrice.HasValue && tmpMinPossiblePrice >= minPossiblePrice.Value)
                    continue;
                minPriceProduct = associatedProduct;
                minPossiblePrice = tmpMinPossiblePrice;
            }

            if (minPriceProduct == null || minPriceProduct.CustomerEntersPrice)
                return;

            if (minPriceProduct.CallForPrice)
            {
                priceModel.OldPrice = null;
                priceModel.OldPriceValue = null;
                priceModel.Price = await _localizationService.GetResourceAsync("Products.CallForPrice");
                priceModel.PriceValue = null;
            }
            else
            {
                //calculate prices
                var (finalPriceBase, _) =
                    await _taxService.GetProductPriceAsync(minPriceProduct, minPossiblePrice.Value);
                var finalPrice = await _currencyService.ConvertFromPrimaryStoreCurrencyAsync(finalPriceBase,
                    await _workContext.GetWorkingCurrencyAsync());

                priceModel.OldPrice = null;
                priceModel.OldPriceValue = null;
                priceModel.Price = string.Format(await _localizationService.GetResourceAsync("Products.PriceRangeFrom"),
                    await _priceFormatter.FormatPriceAsync(finalPrice));
                priceModel.PriceValue = finalPrice;

                //PAngV default baseprice (used in Germany)
                priceModel.BasePricePAngV = await _priceFormatter.FormatBasePriceAsync(product, finalPriceBase);
                priceModel.BasePricePAngVValue = finalPriceBase;
            }
        }

        /// <summary>
        /// Prepare the product overview picture model
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="productThumbPictureSize">Product thumb picture size (longest side); pass null to use the default value of media settings</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains picture models
        /// </returns>
        protected virtual async Task<IList<PictureDto>> PrepareProductOverviewPicturesModelAsync(Product product,
            int? productThumbPictureSize = null)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var productName = await _localizationService.GetLocalizedAsync(product, x => x.Name);
            //If a size has been set in the view, we use it in priority
            var pictureSize = productThumbPictureSize ?? 415; // _mediaSettings.ProductThumbPictureSize;

            var pictures = await _pictureService.GetPicturesByProductIdAsync(product.Id,
                false ? 0 : 1); //_catalogSettings.DisplayAllPicturesOnCatalogPages

            //all pictures
            var pictureModels = new List<PictureDto>();
            for (var i = 0; i < pictures.Count; i++)
            {
                var picture = pictures[i];
            }

            return pictureModels;
        }

        /// <summary>
        /// Prepare the product review overview model
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the product review overview model
        /// </returns>
        protected virtual async Task<ProductReviewOverviewDto> PrepareProductReviewOverviewModelAsync(Product product)
        {
            ProductReviewOverviewDto productReview;
            var currentStore = await _storeContext.GetCurrentStoreAsync();

            if (false) //_catalogSettings.ShowProductReviewsPerStore
            {
                //var cacheKey = _staticCacheManager.PrepareKeyForDefaultCache(NopModelCacheDefaults.ProductReviewsModelKey, product, currentStore);

                //productReview = await _staticCacheManager.GetAsync(cacheKey, async () =>
                //{
                var productReviews = await _productService.GetAllProductReviewsAsync(productId: product.Id,
                    approved: true, storeId: currentStore.Id);

                return new ProductReviewOverviewDto
                {
                    RatingSum = productReviews.Sum(pr => pr.Rating),
                    TotalReviews = productReviews.Count
                };
                //});
            }
            else
            {
                productReview = new ProductReviewOverviewDto
                {
                    RatingSum = product.ApprovedRatingSum,
                    TotalReviews = product.ApprovedTotalReviews
                };
            }

            if (productReview != null)
            {
                productReview.ProductId = product.Id;
                productReview.AllowCustomerReviews = product.AllowCustomerReviews;
                // productReview.CanAddNewReview = await _productService.CanAddReviewAsync(product.Id, _catalogSettings.ShowProductReviewsPerStore ? currentStore.Id : 0);
            }

            return productReview;
        }

        /// <summary>
        /// Prepare the product specification models
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="group">Specification attribute group</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the list of product specification model
        /// </returns>
        protected virtual async Task<IList<ProductSpecificationAttributeModel>>
            PrepareProductSpecificationAttributeModelAsync(Product product, Specificationattributegroup group)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var productSpecificationAttributes =
                await _specificationAttributeService.GetProductSpecificationAttributesAsync(
                    product.Id, specificationAttributeGroupId: group?.Id, showOnProductPage: true);

            var result = new List<ProductSpecificationAttributeModel>();

            foreach (var psa in productSpecificationAttributes)
            {
                var option =
                    await _specificationAttributeService.GetSpecificationAttributeOptionByIdAsync(
                        psa.SpecificationAttributeOptionId);

                var model = result.FirstOrDefault(model => model.Id == option.SpecificationAttributeId);
                if (model == null)
                {
                    var attribute =
                        await _specificationAttributeService.GetSpecificationAttributeByIdAsync(
                            option.SpecificationAttributeId);
                    model = new ProductSpecificationAttributeModel
                    {
                        Id = attribute.Id,
                        Name = await _localizationService.GetLocalizedAsync(attribute, x => x.Name)
                    };
                    result.Add(model);
                }

                var value = new ProductSpecificationAttributeValueModel
                {
                    AttributeTypeId = psa.AttributeTypeId,
                    ColorSquaresRgb = option.ColorSquaresRgb,
                    ValueRaw = (SpecificationAttributeTypeEnum)psa.AttributeTypeId switch
                    {
                        SpecificationAttributeTypeEnum.Option => WebUtility.HtmlEncode(
                            await _localizationService.GetLocalizedAsync(option, x => x.Name)),
                        SpecificationAttributeTypeEnum.CustomText => WebUtility.HtmlEncode(
                            await _localizationService.GetLocalizedAsync(psa, x => x.CustomValue)),
                        SpecificationAttributeTypeEnum.CustomHtmlText => await _localizationService.GetLocalizedAsync(
                            psa, x => x.CustomValue),
                        SpecificationAttributeTypeEnum.Hyperlink =>
                            $"<a href='{psa.CustomValue}' target='_blank'>{psa.CustomValue}</a>",
                        _ => null
                    }
                };

                model.Values.Add(value);
            }

            return result;
        }

        protected async Task<(PictureModel pictureModel, IList<PictureModel> allPictureModels)>
            PrepareProductDetailsPictureModelAsync(Product product, bool isAssociatedProduct)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            //default picture size
            var defaultPictureSize = isAssociatedProduct
                ? _mediaSettings.AssociatedProductPictureSize
                : _mediaSettings.ProductDetailsPictureSize;

            //prepare picture models
            var productPicturesCacheKey = _staticCacheManager.PrepareKeyForDefaultCache(
                PreepexModelCacheDefaults.ProductDetailsPicturesModelKey,
                product,
                defaultPictureSize,
                isAssociatedProduct,
                await _workContext.GetWorkingLanguageAsync(),
                _webHelper.IsCurrentConnectionSecured(),
                await _storeContext.GetCurrentStoreAsync()
            );
            var cachedPictures = await _staticCacheManager.GetAsync(productPicturesCacheKey, async () =>
            {
                var productName = await _localizationService.GetLocalizedAsync(product, x => x.Name);

                var pictures = await _pictureService.GetPicturesByProductIdAsync(product.Id);
                var defaultPicture = pictures.FirstOrDefault();

                string fullSizeImageUrl, imageUrl, thumbImageUrl;
                (imageUrl, defaultPicture) = await _pictureService
                    .GetPictureUrlAsync(defaultPicture, defaultPictureSize, !isAssociatedProduct);
                (fullSizeImageUrl, defaultPicture) = await _pictureService
                    .GetPictureUrlAsync(defaultPicture, 0, !isAssociatedProduct);

                var defaultPictureModel = new PictureModel
                {
                    ImageUrl = imageUrl,
                    FullSizeImageUrl = fullSizeImageUrl
                };
                //"title" attribute
                defaultPictureModel.Title =
                    (defaultPicture != null && !string.IsNullOrEmpty(defaultPicture.TitleAttribute))
                        ? defaultPicture.TitleAttribute
                        : string.Format(
                            await _localizationService.GetResourceAsync("Media.Product.ImageLinkTitleFormat.Details"),
                            productName);
                //"alt" attribute
                defaultPictureModel.AlternateText =
                    (defaultPicture != null && !string.IsNullOrEmpty(defaultPicture.AltAttribute))
                        ? defaultPicture.AltAttribute
                        : string.Format(
                            await _localizationService.GetResourceAsync(
                                "Media.Product.ImageAlternateTextFormat.Details"), productName);

                //all pictures
                var pictureModels = new List<PictureModel>();
                for (var i = 0; i < pictures.Count; i++)
                {
                    var picture = pictures[i];

                    (imageUrl, picture) = await _pictureService
                        .GetPictureUrlAsync(picture, defaultPictureSize, !isAssociatedProduct);
                    (fullSizeImageUrl, picture) = await _pictureService.GetPictureUrlAsync(picture);
                    (thumbImageUrl, picture) = await _pictureService
                        .GetPictureUrlAsync(picture, _mediaSettings.ProductThumbPictureSizeOnProductDetailsPage);

                    var pictureModel = new PictureModel
                    {
                        ImageUrl = imageUrl,
                        ThumbImageUrl = thumbImageUrl,
                        FullSizeImageUrl = fullSizeImageUrl,
                        Title = string.Format(
                            await _localizationService.GetResourceAsync("Media.Product.ImageLinkTitleFormat.Details"),
                            productName),
                        AlternateText =
                            string.Format(
                                await _localizationService.GetResourceAsync(
                                    "Media.Product.ImageAlternateTextFormat.Details"), productName),
                    };
                    //"title" attribute
                    pictureModel.Title = !string.IsNullOrEmpty(picture.TitleAttribute)
                        ? picture.TitleAttribute
                        : string.Format(
                            await _localizationService.GetResourceAsync("Media.Product.ImageLinkTitleFormat.Details"),
                            productName);
                    //"alt" attribute
                    pictureModel.AlternateText = !string.IsNullOrEmpty(picture.AltAttribute)
                        ? picture.AltAttribute
                        : string.Format(
                            await _localizationService.GetResourceAsync(
                                "Media.Product.ImageAlternateTextFormat.Details"), productName);

                    pictureModels.Add(pictureModel);
                }

                return new { DefaultPictureModel = defaultPictureModel, PictureModels = pictureModels };
            });

            var allPictureModels = cachedPictures.PictureModels;
            return (cachedPictures.DefaultPictureModel, allPictureModels);
        }

        protected async Task<Dictionary<int, (PictureModel pictureModel, IList<PictureModel> allPictureModels)>>
            PrepareProductDetailsPictureModelsAsync(IEnumerable<Product> products, bool isAssociatedProduct)
        {
            var result = new Dictionary<int, (PictureModel pictureModel, IList<PictureModel> allPictureModels)>();

            var productsList = products.ToList();

            var allPictures =
                await _pictureService.GetPicturesByProductIdsAsync(productsList.Select(p => p.Id).ToList());
            var localizedNames = await _localizationService.GetLocalizedBatchAsync(productsList, x => x.Name);

            var tasks = new List<Task>();

            foreach (var product in productsList)
            {
                tasks.Add(Task.Run(async () =>
                {
                    var pictures = allPictures.TryGetValue(product.Id, out var allPicture) ? allPicture : new List<Picture>();
                    var productName = localizedNames.TryGetValue(product.Id, out var name)
                        ? name
                        : product.Name;

                    var defaultPicture = pictures.FirstOrDefault();

                    // Get URLs for the default picture
                    string fullSizeImageUrl, imageUrl;
                    (imageUrl, defaultPicture) = await _pictureService.GetPictureUrlAsync(defaultPicture,
                        _mediaSettings.ProductDetailsPictureSize, !isAssociatedProduct);
                    (fullSizeImageUrl, defaultPicture) =
                        await _pictureService.GetPictureUrlAsync(defaultPicture, 0, !isAssociatedProduct);

                    var defaultPictureModel = new PictureModel
                    {
                        ImageUrl = imageUrl,
                        FullSizeImageUrl = fullSizeImageUrl,
                        Title = defaultPicture != null && !string.IsNullOrEmpty(defaultPicture.TitleAttribute)
                            ? defaultPicture.TitleAttribute
                            : string.Format(
                                await _localizationService.GetResourceAsync(
                                    "Media.Product.ImageLinkTitleFormat.Details"), productName),
                        AlternateText = defaultPicture != null && !string.IsNullOrEmpty(defaultPicture.AltAttribute)
                            ? defaultPicture.AltAttribute
                            : string.Format(
                                await _localizationService.GetResourceAsync(
                                    "Media.Product.ImageAlternateTextFormat.Details"), productName)
                    };

                    var pictureModels = new List<PictureModel>();
                    foreach (var picture in pictures)
                    {
                        var tempPicture = picture;
                        // Get URLs for each picture
                        string thumbImageUrl;
                        (imageUrl, tempPicture) = await _pictureService.GetPictureUrlAsync(tempPicture, _mediaSettings.ProductDetailsPictureSize, !isAssociatedProduct);
                        (fullSizeImageUrl, tempPicture) = await _pictureService.GetPictureUrlAsync(tempPicture);
                        (thumbImageUrl, tempPicture) = await _pictureService.GetPictureUrlAsync(tempPicture,
                            _mediaSettings.ProductThumbPictureSizeOnProductDetailsPage);

                        var pictureModel = new PictureModel
                        {
                            ImageUrl = imageUrl,
                            ThumbImageUrl = thumbImageUrl,
                            FullSizeImageUrl = fullSizeImageUrl,
                            Title = !string.IsNullOrEmpty(tempPicture.TitleAttribute)
                                ? tempPicture.TitleAttribute
                                : string.Format(
                                    await _localizationService.GetResourceAsync(
                                        "Media.Product.ImageLinkTitleFormat.Details"), productName),
                            AlternateText = !string.IsNullOrEmpty(tempPicture.AltAttribute)
                                ? tempPicture.AltAttribute
                                : string.Format(
                                    await _localizationService.GetResourceAsync(
                                        "Media.Product.ImageAlternateTextFormat.Details"), productName)
                        };

                        pictureModels.Add(pictureModel);
                    }

                    // Add them to the result dictionary.
                    result[product.Id] = (defaultPictureModel, pictureModels);
                }));
            }

            await Task.WhenAll(tasks);

            return result;
        }


        protected async Task<IList<Core.Application.Models.ProductSpecificationAttributeModel>>
            PrepareProductSpecificationAttributeModelAsync(int productId, int? specificationAttributeGroupId = 0)
        {
            if (productId == 0)
                throw new ArgumentNullException(nameof(productId));

            var productSpecificationAttributes =
                await _specificationAttributeService.GetProductSpecificationAttributesAsync(
                    productId, showOnProductPage: true, specificationAttributeGroupId: specificationAttributeGroupId);

            var result = new List<Core.Application.Models.ProductSpecificationAttributeModel>();

            foreach (var psa in productSpecificationAttributes)
            {
                var option =
                    await _specificationAttributeService.GetSpecificationAttributeOptionByIdAsync(
                        psa.SpecificationAttributeOptionId);

                var model = result.FirstOrDefault(model => model.Id == option.SpecificationAttributeId);
                if (model == null)
                {
                    var attribute =
                        await _specificationAttributeService.GetSpecificationAttributeByIdAsync(
                            option.SpecificationAttributeId);
                    model = new Core.Application.Models.ProductSpecificationAttributeModel
                    {
                        Id = attribute.Id,
                        Name = attribute.Name
                    };
                    result.Add(model);
                }

                var value = new Core.Application.Models.ProductSpecificationAttributeValueModel
                {
                    AttributeTypeId = psa.AttributeTypeId,
                    ColorSquaresRgb = option.ColorSquaresRgb,
                    ValueRaw = (SpecificationAttributeTypeEnum)psa.AttributeTypeId switch
                    {
                        SpecificationAttributeTypeEnum.Option => WebUtility.HtmlEncode(option.Name),
                        SpecificationAttributeTypeEnum.CustomText => WebUtility.HtmlEncode(psa.CustomValue),
                        SpecificationAttributeTypeEnum.CustomHtmlText => psa.CustomValue,
                        SpecificationAttributeTypeEnum.Hyperlink =>
                            $"<a href='{psa.CustomValue}' target='_blank'>{psa.CustomValue}</a>",
                        _ => null
                    }
                };

                model.Values.Add(value);
            }

            return result;
        }

        #endregion
    }
}