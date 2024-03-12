using Swiftrade.Core.Application.Interfaces;
using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Application.Interfaces.Shared;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Core.Domain.Entities.Directory;
using Swiftrade.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swiftrade.Infrastructure.Services
{
    public partial class CurrencyService : ICurrencyService
    {
        #region Fields

        private readonly CurrencySettings _currencySettings;
        private readonly IGenericRepository<Currency> _currencyRepository;
        private readonly IStoreMappingService _storeMappingService;

        #endregion

        #region Ctor

        public CurrencyService(CurrencySettings currencySettings,
            IGenericRepository<Currency> currencyRepository, IStoreMappingService storeMappingService)
        {
            _currencySettings = currencySettings;
            _currencyRepository = currencyRepository;
            _storeMappingService = storeMappingService;
        }

        #endregion

        #region methods
        public async Task<decimal> ConvertFromPrimaryStoreCurrencyAsync(decimal amount, Currency targetCurrencyCode)
        {
            var primaryStoreCurrency = await GetCurrencyByIdAsync(_currencySettings.PrimaryStoreCurrencyId);
            var result = await ConvertCurrencyAsync(amount, primaryStoreCurrency, targetCurrencyCode);

            return result;
        }

        public virtual async Task<Currency> GetCurrencyByIdAsync(int currencyId)
        {
            return await _currencyRepository.GetByIdAsync(currencyId, cache => default);
        }

        public virtual async Task<decimal> ConvertCurrencyAsync(decimal amount, Currency sourceCurrencyCode, Currency targetCurrencyCode)
        {
            if (sourceCurrencyCode == null)
                throw new ArgumentNullException(nameof(sourceCurrencyCode));

            if (targetCurrencyCode == null)
                throw new ArgumentNullException(nameof(targetCurrencyCode));

            var result = amount;

            if (result == decimal.Zero || sourceCurrencyCode.Id == targetCurrencyCode.Id)
                return result;

            result = await ConvertToPrimaryExchangeRateCurrencyAsync(result, sourceCurrencyCode);
            result = await ConvertFromPrimaryExchangeRateCurrencyAsync(result, targetCurrencyCode);
            return result;
        }

        public virtual async Task<decimal> ConvertToPrimaryExchangeRateCurrencyAsync(decimal amount, Currency sourceCurrencyCode)
        {
            if (sourceCurrencyCode == null)
                throw new ArgumentNullException(nameof(sourceCurrencyCode));

            var primaryExchangeRateCurrency = await GetCurrencyByIdAsync(_currencySettings.PrimaryExchangeRateCurrencyId);
            if (primaryExchangeRateCurrency == null)
                throw new Exception("Primary exchange rate currency cannot be loaded");

            var result = amount;
            if (result == decimal.Zero || sourceCurrencyCode.Id == primaryExchangeRateCurrency.Id)
                return result;

            var exchangeRate = sourceCurrencyCode.Rate;
            if (exchangeRate == decimal.Zero)
                throw new Exception($"Exchange rate not found for currency [{sourceCurrencyCode.Name}]");
            result /= exchangeRate;

            return result;
        }

        public virtual async Task<decimal> ConvertFromPrimaryExchangeRateCurrencyAsync(decimal amount, Currency targetCurrencyCode)
        {
            if (targetCurrencyCode == null)
                throw new ArgumentNullException(nameof(targetCurrencyCode));

            var primaryExchangeRateCurrency = await GetCurrencyByIdAsync(_currencySettings.PrimaryExchangeRateCurrencyId);
            if (primaryExchangeRateCurrency == null)
                throw new Exception("Primary exchange rate currency cannot be loaded");

            var result = amount;
            if (result == decimal.Zero || targetCurrencyCode.Id == primaryExchangeRateCurrency.Id)
                return result;

            var exchangeRate = targetCurrencyCode.Rate;
            if (exchangeRate == decimal.Zero)
                throw new Exception($"Exchange rate not found for currency [{targetCurrencyCode.Name}]");
            result *= exchangeRate;

            return result;
        }

        /// <summary>
        /// Gets a currency by code
        /// </summary>
        /// <param name="currencyCode">Currency code</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the currency
        /// </returns>
        public virtual async Task<Currency> GetCurrencyByCodeAsync(string currencyCode)
        {
            if (string.IsNullOrEmpty(currencyCode))
                return null;

            return (await GetAllCurrenciesAsync(true))
                .FirstOrDefault(c => c.CurrencyCode.ToLowerInvariant() == currencyCode.ToLowerInvariant());
        }

        /// <summary>
        /// Converts currency
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="exchangeRate">Currency exchange rate</param>
        /// <returns>Converted value</returns>
        public virtual decimal ConvertCurrency(decimal amount, decimal exchangeRate)
        {
            if (amount != decimal.Zero && exchangeRate != decimal.Zero)
                return amount * exchangeRate;

            return decimal.Zero;
        }

        /// <summary>
        /// Gets all currencies
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the currencies
        /// </returns>
        public virtual async Task<IList<Currency>> GetAllCurrenciesAsync(bool showHidden = false, int storeId = 0)
        {
            var currencies = await _currencyRepository.GetAllAsync(query =>
            {
                if (!showHidden)
                    query = query.Where(c => c.Published);

                query = query.OrderBy(c => c.DisplayOrder).ThenBy(c => c.Id);

                return query;
            }, cache => cache.PrepareKeyForDefaultCache(SwiftradeDirectoryDefaults.CurrenciesAllCacheKey, showHidden));

            //store mapping
            if (storeId > 0)
                currencies = await currencies
                    .WhereAwait(async c => await _storeMappingService.AuthorizeAsync(c, storeId))
                    .ToListAsync();

            return currencies;
        }

        #endregion
    }
}
