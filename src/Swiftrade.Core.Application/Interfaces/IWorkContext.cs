using Swiftrade.Core.Domain.Entities;
using Swiftrade.Core.Domain.Entities.Tax;
using System.Threading.Tasks;

namespace Swiftrade.Core.Application.Interfaces
{
    /// <summary>
    /// Represents work context
    /// </summary>
    public interface IWorkContext
    {
        /// <summary>
        /// Gets the current customer
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<Customer> GetCurrentCustomerAsync();

        /// <summary>
        /// Gets or sets current tax display type
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<TaxDisplayType> GetTaxDisplayTypeAsync();

        /// <summary>
        /// Gets or sets current user working currency
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<Currency> GetWorkingCurrencyAsync();


        /// <summary>
        /// Gets current user working language
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<Language> GetWorkingLanguageAsync();



    }
}
