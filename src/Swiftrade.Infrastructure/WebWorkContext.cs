using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Swiftrade.Core.Application.Caching;
using Swiftrade.Core.Application.Interfaces;
using Swiftrade.Core.Application.Interfaces.Shared;
using Swiftrade.Core.Application.Interfaces.Shared.Customers;
using Swiftrade.Core.Domain;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Core.Domain.Entities.Tax;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Swiftrade.Infrastructure
{
    /// <summary>
    /// Represents work context for web application
    /// </summary>
    public partial class WebWorkContext : IWorkContext
    {
        #region declaration
        private readonly IHttpContextAccessor _httpContextAccessor;
        private Customer _cachedCustomer;
        private ICustomerService _customerService;
        private IStoreContext _storeContext;
        private TaxSettings _taxSetting;
        private ICurrencyService _currencyService;
        private ILanguageService _languageService;
        private Language _cachedLanguage;
        private Currency _cachedCurrency;
        private readonly IGenericAttributeService _genericAttributeService;

        #endregion

        #region ctor

        public WebWorkContext(IHttpContextAccessor httpContextAccessor, ICustomerService customerService, IStoreContext storeContext,
            TaxSettings taxSettings, ICurrencyService currencyService, ILanguageService languageService, IGenericAttributeService genericAttributeService)
        {
            _httpContextAccessor = httpContextAccessor;
            _customerService = customerService;
            _storeContext = storeContext;
            _taxSetting = taxSettings;
            _currencyService = currencyService;
            _languageService = languageService;
            _genericAttributeService = genericAttributeService;
        }

        #endregion

        #region methods
        /// <summary>
        /// Gets the current customer
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<Customer> GetCurrentCustomerAsync()
        {
            //whether there is a cached value
            if (_cachedCustomer != null)
                return _cachedCustomer;

            var customers = await _customerService.GetAllCustomersAsync();
            var customer = customers.FirstOrDefault();
           
            _cachedCustomer = customer;
            return _cachedCustomer;
        }

        /// <summary>
        /// Gets or sets current tax display type
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<TaxDisplayType> GetTaxDisplayTypeAsync()
        {
            var taxDisplayType = TaxDisplayType.IncludingTax;
            var customer = await GetCurrentCustomerAsync();
            var store = await _storeContext.GetCurrentStoreAsync();

            //whether customers are allowed to select tax display type
            if (_taxSetting.AllowCustomersToSelectTaxDisplayType && customer != null)
            {
                //try to get previously saved tax display type
                //var taxDisplayTypeId = await _genericAttributeService
                //    .GetAttributeAsync<int?>(customer, "TaxDisplayTypeId", store.Id);
                //if (taxDisplayTypeId.HasValue)
                    taxDisplayType = (TaxDisplayType)1;
                //else
                //{
                //    //default tax type by customer roles
                //    var defaultRoleTaxDisplayType = await _customerService.GetCustomerDefaultTaxDisplayTypeAsync(customer);
                //    if (defaultRoleTaxDisplayType != null)
                //        taxDisplayType = defaultRoleTaxDisplayType.Value;
                //}
            }
            //else
            //{
            //    //default tax type by customer roles
            //    var defaultRoleTaxDisplayType = await _customerService.GetCustomerDefaultTaxDisplayTypeAsync(customer);
            //    if (defaultRoleTaxDisplayType != null)
            //        taxDisplayType = defaultRoleTaxDisplayType.Value;
            //    else
            //    {
            //        //or get the default tax display type
            //        taxDisplayType = _taxSetting.TaxDisplayType;
            //    }
            //}

            return taxDisplayType;
        }

        /// <summary>
        /// Gets current user working currency
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<Currency> GetWorkingCurrencyAsync()
        {
            //whether there is a cached value
            if (_cachedCurrency != null)
                return _cachedCurrency;

            var customer = await GetCurrentCustomerAsync();
            var store = await _storeContext.GetCurrentStoreAsync();

            //find a currency previously selected by a customer
            var customerCurrencyId = await _genericAttributeService
             .GetAttributeAsync<int>(customer, SwiftradeCustomerDefaults.CurrencyIdAttribute, store.Id);

            var allStoreCurrencies = await _currencyService.GetAllCurrenciesAsync(storeId: store.Id);

            //check customer currency availability
            var customerCurrency = allStoreCurrencies.FirstOrDefault(currency => currency.Id == customerCurrencyId);
            if (customerCurrency == null)
            {
                customerCurrency = allStoreCurrencies.OrderBy(currency=>currency.DisplayOrder)
                    .FirstOrDefault();
            }

            //if the default currency for the current store not found, then try to get the first one
            if (customerCurrency == null)
                customerCurrency = allStoreCurrencies.FirstOrDefault();

            //if there are no currencies for the current store try to get the first one regardless of the store
            if (customerCurrency == null)
                customerCurrency = (await _currencyService.GetAllCurrenciesAsync()).FirstOrDefault();

            //cache the found currency
            _cachedCurrency = customerCurrency;

            return _cachedCurrency;
        }


        /// <summary>
        /// Gets current user working language
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<Language> GetWorkingLanguageAsync()
        {
            //whether there is a cached value
            if (_cachedLanguage != null)
                return _cachedLanguage;

            var customer = await GetCurrentCustomerAsync();
            var store = await _storeContext.GetCurrentStoreAsync();

            //whether we should detect the language from the request
            var detectedLanguage = await GetLanguageFromRequestAsync();

            //get current saved language identifier
            var currentLanguageId = 1;

            //if the language is detected we need to save it
            if (detectedLanguage != null)
            {
                //save the detected language identifier if it differs from the current one
                if (detectedLanguage.Id != currentLanguageId)
                    await SetWorkingLanguageAsync(detectedLanguage);
            }
            else
            {
                var allStoreLanguages = await _languageService.GetAllLanguagesAsync(storeId: store.Id);

                //check customer language availability
                detectedLanguage = allStoreLanguages.FirstOrDefault(language => language.Id == currentLanguageId);

                //it not found, then try to get the default language for the current store (if specified)
                detectedLanguage ??= allStoreLanguages.FirstOrDefault(language => language.Id == store.DefaultLanguageId);

                //if the default language for the current store not found, then try to get the first one
                detectedLanguage ??= allStoreLanguages.FirstOrDefault();

                //if there are no languages for the current store try to get the first one regardless of the store
                detectedLanguage ??= (await _languageService.GetAllLanguagesAsync()).FirstOrDefault();

                SetLanguageCookie(detectedLanguage);
            }

            //cache the found language
            _cachedLanguage = detectedLanguage;

            return _cachedLanguage;
        }

        /// <summary>
        /// Sets current user working language
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task SetWorkingLanguageAsync(Language language)
        {
            //save passed language identifier
            var customer = await GetCurrentCustomerAsync();
            var store = await _storeContext.GetCurrentStoreAsync();
            //await _genericAttributeService.SaveAttributeAsync(customer, "LanguageId", language?.Id ?? 0, store.Id);

            //set cookie
            SetLanguageCookie(language);

            //then reset the cached value
            _cachedLanguage = null;
        }

        /// <summary>
        /// Set language culture cookie
        /// </summary>
        /// <param name="language">Language</param>
        protected virtual void SetLanguageCookie(Language language)
        {
            if (_httpContextAccessor.HttpContext?.Response?.HasStarted ?? true)
                return;

            //delete current cookie value
            var cookieName = $"{EntityCacheDefaults<Setting>.Prefix}{EntityCacheDefaults<Setting>.CultureCookie}";
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(cookieName);

            if (string.IsNullOrEmpty(language?.LanguageCulture))
                return;

            //set new cookie value
            var value = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(language.LanguageCulture));
            var options = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) };
            _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieName, value, options);
        }

        /// <summary>
        /// Get language from the request
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the found language
        /// </returns>
        protected virtual async Task<Language> GetLanguageFromRequestAsync()
        {
            var requestCultureFeature = _httpContextAccessor.HttpContext?.Features.Get<IRequestCultureFeature>();
            if (requestCultureFeature is null)
                return null;

            //get request culture
            if (requestCultureFeature.RequestCulture is null)
                return null;

            //try to get language by culture name
            var requestLanguage = (await _languageService.GetAllLanguagesAsync()).FirstOrDefault(language =>
                language.LanguageCulture.Equals(requestCultureFeature.RequestCulture.Culture.Name, StringComparison.InvariantCultureIgnoreCase));

            return requestLanguage;
        }

        #endregion

        #region Utilities

        #endregion

    }
}
