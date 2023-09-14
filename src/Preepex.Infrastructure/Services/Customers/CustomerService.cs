using Preepex.Core.Application.Interfaces.Shared.Customers;
using Preepex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Caching;

namespace Preepex.Infrastructure.Services.Customers
{
    public partial class CustomerService : ICustomerService
    {

        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        public CustomerService(IGenericRepository<Customer> customerRepository, IGenericRepository<Customerrole> customerRoleRepository,
                        IStaticCacheManager staticCacheManager)
        {
            _customerRepository = customerRepository;
            _staticCacheManager = staticCacheManager;

        }

        /// <summary>
        /// Gets a customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a customer
        /// </returns>
        public virtual async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _customerRepository.GetByIdAsync(customerId);
        }

        public async Task<IReadOnlyList<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.ListAllAsync();
        }

        public virtual async Task<Customer> GetOrCreateBackgroundTaskUserAsync()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Get customer role identifiers
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="showHidden">A value indicating whether to load hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the customer role identifiers
        /// </returns>
        public virtual async Task<int[]> GetCustomerRoleIdsAsync(Customer customer, bool showHidden = false)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));


            var query = _customerRepository.Table.SelectMany(x => x.CustomerRole)
                .Where(x => x.Id == customer.Id && (x.Active || showHidden))
                .Select(x => x.Id).ToList();

            var key = _staticCacheManager.PrepareKeyForShortTermCache(PreepexCustomerServicesDefaults.CustomerRoleIdsCacheKey, customer, showHidden);

            return await _staticCacheManager.GetAsync(key, () => query.ToArray());
        }

        async Task<IList<Customer>> ICustomerService.GetAllCustomersAsync()
        {
            return (IList<Customer>)await _customerRepository.ListAllAsync();
        }
    }
}
