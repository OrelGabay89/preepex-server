using Swiftrade.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Swiftrade.Core.Application.Interfaces.Shared.Tax
{
    public partial interface ITaxService
    {
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
        Task<(decimal price, decimal taxRate)> GetProductPriceAsync(Product product, decimal price);

        #endregion
    }
}
    