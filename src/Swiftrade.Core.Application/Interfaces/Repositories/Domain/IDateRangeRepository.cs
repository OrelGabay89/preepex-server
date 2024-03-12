using Swiftrade.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Swiftrade.Core.Application.Interfaces.Repositories.Domain
{
    /// <summary>
    /// Date range service interface
    /// </summary>
    public interface IDateRangeRepository
    {
        /// <summary>
        /// Get a delivery date
        /// </summary>
        /// <param name="deliveryDateId">The delivery date identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the delivery date
        /// </returns>
        Task<Deliverydate> GetDeliveryDateByIdAsync(int deliveryDateId);
    }
}
