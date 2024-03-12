using Swiftrade.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Swiftrade.Core.Application.Interfaces.Shared
{
    public partial interface ICurrencyService
    {
        Task<Currency> GetCurrencyByIdAsync(int currencyId);

        /// <summary>
        /// Converts from primary store currency
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="targetCurrencyCode">Target currency code</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the converted value
        /// </returns>
        Task<decimal> ConvertFromPrimaryStoreCurrencyAsync(decimal amount, Currency targetCurrencyCode);

        /// <summary>
        /// Gets all currencies
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the currencies
        /// </returns>
        Task<IList<Currency>> GetAllCurrenciesAsync(bool showHidden = false, int storeId = 0);

        /// <summary>
        /// Gets a currency by code
        /// </summary>
        /// <param name="currencyCode">Currency code</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the currency
        /// </returns>
        Task<Currency> GetCurrencyByCodeAsync(string currencyCode);

        /// <summary>
        /// Converts currency
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="exchangeRate">Currency exchange rate</param>
        /// <returns>Converted value</returns>
        decimal ConvertCurrency(decimal amount, decimal exchangeRate);
    }
}
