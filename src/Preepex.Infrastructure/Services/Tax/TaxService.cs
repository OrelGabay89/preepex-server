using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Shared.Customers;
using Preepex.Core.Application.Interfaces.Shared.Tax;
using Preepex.Core.Domain.Entities;
using Preepex.Core.Domain.Entities.Tax;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Services.Tax
{
    public partial class TaxService : ITaxService
    {
        #region Fields
        protected readonly ICustomerService _customerService;
        protected readonly IWorkContext _workContext;
        private TaxSettings _taxSetting;
        private IStoreContext _storeContext;
        #endregion

        #region Ctor

        public TaxService(ICustomerService customerService, IWorkContext workContext, TaxSettings taxSetting, IStoreContext storeContext)
        {
            _customerService= customerService;
            _workContext= workContext;  
            _taxSetting= taxSetting;    
            _storeContext= storeContext;
        }

        #endregion

        #region Product price

        /// <summary>
        /// Gets price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="price">Price</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the price. Tax rate
        /// </returns>
        public virtual async Task<(decimal price, decimal taxRate)> GetProductPriceAsync(Product product, decimal price)
        {
            var customer = await _workContext.GetCurrentCustomerAsync();

            return await GetProductPriceAsync(product, price, customer);
        }

        /// <summary>
        /// Gets price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="price">Price</param>
        /// <param name="customer">Customer</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the price. Tax rate
        /// </returns>
        public virtual async Task<(decimal price, decimal taxRate)> GetProductPriceAsync(Product product, decimal price,
            Customer customer)
        {
            var includingTax = await _workContext.GetTaxDisplayTypeAsync() == TaxDisplayType.IncludingTax;
            return await GetProductPriceAsync(product, price, includingTax, customer);
        }

        /// <summary>
        /// Gets price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="price">Price</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the price. Tax rate
        /// </returns>
        public virtual async Task<(decimal price, decimal taxRate)> GetProductPriceAsync(Product product, decimal price,
            bool includingTax, Customer customer)
        {
            var priceIncludesTax = _taxSetting.PricesIncludeTax;
            var taxCategoryId = 0;
            return await GetProductPriceAsync(product, taxCategoryId, price, includingTax, customer, priceIncludesTax);
        }

        /// <summary>
        /// Gets price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="taxCategoryId">Tax category identifier</param>
        /// <param name="price">Price</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <param name="priceIncludesTax">A value indicating whether price already includes tax</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the price. Tax rate
        /// </returns>
        public virtual async Task<(decimal price, decimal taxRate)> GetProductPriceAsync(Product product, int taxCategoryId,
            decimal price, bool includingTax, Customer customer,
            bool priceIncludesTax)
        {
            var taxRate = decimal.Zero;

            //no need to calculate tax rate if passed "price" is 0
            if (price == decimal.Zero)
                return (price, taxRate);

            bool isTaxable;

            (taxRate, isTaxable) = await GetTaxRateAsync(product, taxCategoryId, customer, price);

            if (priceIncludesTax)
            {
                //"price" already includes tax
                if (includingTax)
                {
                    //we should calculate price WITH tax
                    if (!isTaxable)
                    {
                        //but our request is not taxable
                        //hence we should calculate price WITHOUT tax
                        price = CalculatePrice(price, taxRate, false);
                    }
                }
                else
                {
                    //we should calculate price WITHOUT tax
                    price = CalculatePrice(price, taxRate, false);
                }
            }
            else
            {
                //"price" doesn't include tax
                if (includingTax)
                {
                    //we should calculate price WITH tax
                    //do it only when price is taxable
                    if (isTaxable)
                    {
                        price = CalculatePrice(price, taxRate, true);
                    }
                }
            }

            if (!isTaxable)
            {
                //we return 0% tax rate in case a request is not taxable
                taxRate = decimal.Zero;
            }

            //allowed to support negative price adjustments
            //if (price < decimal.Zero)
            //    price = decimal.Zero;

            return (price, taxRate);
        }

        /// <summary>
        /// Gets tax rate
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="taxCategoryId">Tax category identifier</param>
        /// <param name="customer">Customer</param>
        /// <param name="price">Price (taxable value)</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the calculated tax rate. A value indicating whether a request is taxable
        /// </returns>
        protected virtual async Task<(decimal taxRate, bool isTaxable)> GetTaxRateAsync(Product product, int taxCategoryId,
            Customer customer, decimal price)
        {
            var taxRate = decimal.Zero;

            //active tax provider
            var store = await _storeContext.GetCurrentStoreAsync();
            //var activeTaxProvider = await _taxPluginManager.LoadPrimaryPluginAsync(customer, store.Id);
            //if (activeTaxProvider == null)
              //  return (taxRate, true);

            //tax request
           // var taxRateRequest = await PrepareTaxRateRequestAsync(product, taxCategoryId, customer, price);

            var isTaxable = true;

            //tax exempt

            //make EU VAT exempt validation (the European Union Value Added Tax)
            //if (isTaxable &&
            //    _taxSetting.EuVatEnabled &&
            //    await IsVatExemptAsync(taxRateRequest.Address, taxRateRequest.Customer))
            //    //VAT is not chargeable
            //    isTaxable = false;

            //get tax rate
            //var taxRateResult = await activeTaxProvider.GetTaxRateAsync(taxRateRequest);

            ////tax rate is calculated, now consumers can adjust it
            //await _eventPublisher.PublishAsync(new TaxRateCalculatedEvent(taxRateResult));

            //if (taxRateResult.Success)
            //{
            //    //ensure that tax is equal or greater than zero
            //    if (taxRateResult.TaxRate < decimal.Zero)
            //        taxRateResult.TaxRate = decimal.Zero;

            //    taxRate = taxRateResult.TaxRate;
            //}
            //else if (_taxSetting.LogErrors)
            //    foreach (var error in taxRateResult.Errors)
            //        await _logger.ErrorAsync($"{activeTaxProvider.PluginDescriptor.FriendlyName} - {error}", null, customer);

            return (taxRate, isTaxable);
        }

        /// <summary>
        /// Gets a value indicating whether EU VAT exempt (the European Union Value Added Tax)
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="customer">Customer</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the result
        /// </returns>
        //protected virtual async Task<bool> IsVatExemptAsync(Address address, Customer customer)
        //{
        //    if (!_taxSetting.EuVatEnabled)
        //        return false;

        //    if (customer == null || address == null)
        //        return false;

        //    //var country = await _countryService.GetCountryByIdAsync(address.CountryId ?? 0);
        //    //if (country == null)
        //    //    return false;

        //    //if (!country.SubjectToVat)
        //    //    // VAT not chargeable if shipping outside VAT zone
        //    //    return true;

        //    // VAT not chargeable if address, customer and config meet our VAT exemption requirements:
        //    // returns true if this customer is VAT exempt because they are shipping within the EU but outside our shop country, they have supplied a validated VAT number, and the shop is configured to allow VAT exemption
        //    var customerVatStatus = (VatNumberStatus)await _genericAttributeService.GetAttributeAsync<int>(customer, .VatNumberStatusIdAttribute);

        //    return country.Id != _taxSetting.EuVatShopCountryId &&
        //           customerVatStatus == VatNumberStatus.Valid &&
        //           _taxSetting.EuVatAllowVatExemption;
        //}


        /// <summary>
        /// Calculated price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="percent">Percent</param>
        /// <param name="increase">Increase</param>
        /// <returns>New price</returns>
        protected virtual decimal CalculatePrice(decimal price, decimal percent, bool increase)
        {
            if (percent == decimal.Zero)
                return price;

            decimal result;
            if (increase)
                result = price * (1 + percent / 100);
            else
                result = price - price / (100 + percent) * percent;

            return result;
        }

        /// <summary>
        /// Prepare request to get tax rate
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="taxCategoryId">Tax category identifier</param>
        /// <param name="customer">Customer</param>
        /// <param name="price">Price</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the package for tax calculation
        /// </returns>
        //protected virtual async Task<TaxRateRequest> PrepareTaxRateRequestAsync(Product product, int taxCategoryId, Customer customer, decimal price)
        //{
        //    if (customer == null)
        //        throw new ArgumentNullException(nameof(customer));

        //    var store = await _storeContext.GetCurrentStoreAsync();
        //    var taxRateRequest = new TaxRateRequest
        //    {
        //        Customer = customer,
        //        Product = product,
        //        Price = price,
        //        TaxCategoryId = taxCategoryId > 0 ? taxCategoryId : product?.TaxCategoryId ?? 0,
        //        CurrentStoreId = store.Id
        //    };

        //    var basedOn = _taxSetting.TaxBasedOn;

        //    //new EU VAT rules starting January 1st 2015
        //    //find more info at http://ec.europa.eu/taxation_customs/taxation/vat/how_vat_works/telecom/index_en.htm#new_rules
        //    var overriddenBasedOn =
        //        //EU VAT enabled?
        //        _taxSetting.EuVatEnabled &&
        //        //telecommunications, broadcasting and electronic services?
        //        product != null && product.IsTelecommunicationsOrBroadcastingOrElectronicServices &&
        //        //January 1st 2015 passed? Yes, not required anymore
        //        //DateTime.UtcNow > new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Utc) &&
        //        //Europe Union consumer?
        //        await IsEuConsumerAsync(customer);
        //    if (overriddenBasedOn)
        //    {
        //        //We must charge VAT in the EU country where the customer belongs (not where the business is based)
        //        basedOn = TaxBasedOn.BillingAddress;
        //    }

        //    //tax is based on pickup point address
        //    //if (!overriddenBasedOn && _taxSetting.TaxBasedOnPickupPointAddress && _shippingSettings.AllowPickupInStore)
        //    //{
        //    //    var pickupPoint = await _genericAttributeService.GetAttributeAsync<PickupPoint>(customer,
        //    //        NopCustomerDefaults.SelectedPickupPointAttribute, store.Id);
        //    //    if (pickupPoint != null)
        //    //    {
        //    //        taxRateRequest.Address = await LoadPickupPointTaxAddressAsync(pickupPoint);
        //    //        return taxRateRequest;
        //    //    }
        //    //}

        //    if (basedOn == TaxBasedOn.BillingAddress && customer.BillingAddressId == null ||
        //        basedOn == TaxBasedOn.ShippingAddress && customer.ShippingAddressId == null)
        //        basedOn = TaxBasedOn.DefaultAddress;

        //    switch (basedOn)
        //    {
        //        case TaxBasedOn.BillingAddress:
        //            var billingAddress = await _customerService.GetCustomerBillingAddressAsync(customer);
        //            taxRateRequest.Address = billingAddress;
        //            break;
        //        case TaxBasedOn.ShippingAddress:
        //            var shippingAddress = await _customerService.GetCustomerShippingAddressAsync(customer);
        //            taxRateRequest.Address = shippingAddress;
        //            break;
        //        case TaxBasedOn.DefaultAddress:
        //        default:
        //            taxRateRequest.Address = await LoadDefaultTaxAddressAsync();
        //            break;
        //    }

        //    return taxRateRequest;
        //}

        #endregion
    }
}
