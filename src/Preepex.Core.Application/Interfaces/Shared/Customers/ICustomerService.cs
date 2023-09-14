using Preepex.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Preepex.Core.Application.Interfaces.Shared.Customers
{
    public partial interface ICustomerService
    {
        /// <summary>
        /// Gets built-in system record used for background tasks
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a customer object
        /// </returns>
        Task<Customer> GetOrCreateBackgroundTaskUserAsync();

        /// <summary>
        /// Gets a customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a customer
        /// </returns>
        Task<Customer> GetCustomerByIdAsync(int customerId);

        /// <summary>
        /// Gets a customer
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a customer
        /// </returns>
        Task<IList<Customer>> GetAllCustomersAsync();

        /// <summary>
        /// Get customer role identifiers
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="showHidden">A value indicating whether to load hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the customer role identifiers
        /// </returns>
        Task<int[]> GetCustomerRoleIdsAsync(Customer customer, bool showHidden = false);
    }
}
