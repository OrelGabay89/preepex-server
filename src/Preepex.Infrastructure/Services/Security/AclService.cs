using Preepex.Core.Application.Caching;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Security;
using Preepex.Core.Application.Interfaces.Shared.Customers;
using Preepex.Core.Domain.Entities;
using Preepex.Core.Domain.Entities.Catalog;
using Preepex.Core.Domain.Entities.Common;
using Preepex.Core.Domain.Interfaces;
using Preepex.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Services.Security
{
    public partial class AclService : IAclService
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly ICustomerService _customerService;
        private readonly IGenericRepository<Aclrecord> _aclRecordRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public AclService(CatalogSettings catalogSettings,
            ICustomerService customerService,
            IGenericRepository<Aclrecord> aclRecordRepository,

            IStaticCacheManager staticCacheManager,
            IWorkContext workContext)
        {
            _catalogSettings = catalogSettings;
            _customerService = customerService;
            _aclRecordRepository = aclRecordRepository;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Inserts an ACL record
        /// </summary>
        /// <param name="aclRecord">ACL record</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        protected virtual async Task InsertAclRecordAsync(Aclrecord aclRecord)
        {
            //TODO

            //await _aclRecordRepository.InsertAsync(aclRecord);
        }

        /// <summary>
        /// Get a value indicating whether any ACL records exist for entity type are related to customer roles
        /// </summary>
        /// <typeparam name="TEntity">Type of entity that supports the ACL</typeparam>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rue if exist; otherwise false
        /// </returns>
        protected virtual async Task<bool> IsEntityAclMappingExistAsync<TEntity>() where TEntity : BaseEntity<int>, IAclSupported
        {
            var entityName = typeof(TEntity).Name;
            var key = _staticCacheManager.PrepareKeyForDefaultCache(PreepexSecurityDefaults.EntityAclRecordExistsCacheKey, entityName);

            var query = from acl in _aclRecordRepository.Table
                        where acl.EntityName == entityName
                        select acl;

            return await _staticCacheManager.GetAsync(key, query.Any);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Apply ACL to the passed query
        /// </summary>
        /// <typeparam name="TEntity">Type of entity that supports the ACL</typeparam>
        /// <param name="query">Query to filter</param>
        /// <param name="customer">Customer</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the filtered query
        /// </returns>
        public virtual async Task<IQueryable<TEntity>> ApplyAcl<TEntity>(IQueryable<TEntity> query, Customer customer)
            where TEntity : BaseEntity<int>, IAclSupported
        {
            if (query is null)
                throw new ArgumentNullException(nameof(query));

            if (customer is null)
                throw new ArgumentNullException(nameof(customer));


            var customerRoleIds = await _customerService.GetCustomerRoleIdsAsync(customer);
            return await ApplyAcl(query, customerRoleIds);
        }

        /// <summary>
        /// Apply ACL to the passed query
        /// </summary>
        /// <typeparam name="TEntity">Type of entity that supports the ACL</typeparam>
        /// <param name="query">Query to filter</param>
        /// <param name="customerRoleIds">Identifiers of customer's roles</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the filtered query
        /// </returns>
        public virtual async Task<IQueryable<TEntity>> ApplyAcl<TEntity>(IQueryable<TEntity> query, int[] customerRoleIds)
            where TEntity : BaseEntity<int>, IAclSupported
        {
            if (query is null)
                throw new ArgumentNullException(nameof(query));

            if (customerRoleIds is null)
                throw new ArgumentNullException(nameof(customerRoleIds));

            if (!customerRoleIds.Any() || _catalogSettings.IgnoreAcl || !await IsEntityAclMappingExistAsync<TEntity>())
                return query;

            return from entity in query
                   where !entity.SubjectToAcl || _aclRecordRepository.Table.Any(acl =>
                        acl.EntityName == typeof(TEntity).Name && acl.EntityId == entity.Id && customerRoleIds.Contains(acl.CustomerRoleId))
                   select entity;
        }

        /// <summary>
        /// Deletes an ACL record
        /// </summary>
        /// <param name="aclRecord">ACL record</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteAclRecordAsync(Aclrecord aclRecord)
        {
            //TODO

            //await _aclRecordRepository.DeleteAsync(aclRecord);
        }

        /// <summary>
        /// Gets ACL records
        /// </summary>
        /// <typeparam name="TEntity">Type of entity that supports the ACL</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the aCL records
        /// </returns>
        public virtual async Task<IList<Aclrecord>> GetAclRecordsAsync<TEntity>(TEntity entity) where TEntity : BaseEntity<int>, IAclSupported
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityId = entity.Id;
            var entityName = entity.GetType().Name;

            var query = from ur in _aclRecordRepository.Table
                        where ur.EntityId == entityId &&
                        ur.EntityName == entityName
                        select ur;
            var aclRecords = await query.ToListAsync();

            return aclRecords;
        }

        /// <summary>
        /// Inserts an ACL record
        /// </summary>
        /// <typeparam name="TEntity">Type of entity that supports the ACL</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="customerRoleId">Customer role id</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertAclRecordAsync<TEntity>(TEntity entity, int customerRoleId) where TEntity : BaseEntity<int>, IAclSupported
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (customerRoleId == 0)
                throw new ArgumentOutOfRangeException(nameof(customerRoleId));

            var entityId = entity.Id;
            var entityName = entity.GetType().Name;

            var aclRecord = new Aclrecord
            {
                EntityId = entityId,
                EntityName = entityName,
                CustomerRoleId = customerRoleId
            };

            await InsertAclRecordAsync(aclRecord);
        }

        /// <summary>
        /// Find customer role identifiers with granted access
        /// </summary>
        /// <typeparam name="TEntity">Type of entity that supports the ACL</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the customer role identifiers
        /// </returns>
        public virtual async Task<int[]> GetCustomerRoleIdsWithAccessAsync<TEntity>(TEntity entity) where TEntity : BaseEntity<int>, IAclSupported
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityId = entity.Id;
            var entityName = entity.GetType().Name;

            var key = _staticCacheManager.PrepareKeyForDefaultCache(PreepexSecurityDefaults.AclRecordCacheKey, entityId, entityName);

            var query = from ur in _aclRecordRepository.Table
                        where ur.EntityId == entityId &&
                              ur.EntityName == entityName
                        select ur.CustomerRoleId;

            return await _staticCacheManager.GetAsync(key, () => query.ToArray());
        }

        /// <summary>
        /// Authorize ACL permission
        /// </summary>
        /// <typeparam name="TEntity">Type of entity that supports the ACL</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rue - authorized; otherwise, false
        public virtual async Task<bool> AuthorizeAsync<TEntity>(TEntity entity) where TEntity : BaseEntity<int>, IAclSupported
        {
            return await AuthorizeAsync(entity, await _workContext.GetCurrentCustomerAsync());
        }

        /// <summary>
        /// Authorize ACL permission
        /// </returns>
        /// </summary>
        /// <typeparam name="TEntity">Type of entity that supports the ACL</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="customer">Customer</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rue - authorized; otherwise, false
        /// </returns>
        public virtual async Task<bool> AuthorizeAsync<TEntity>(TEntity entity, Customer customer) where TEntity : BaseEntity<int>, IAclSupported
        {
            if (entity == null)
                return false;

            if (customer == null)
                return false;

            if (_catalogSettings.IgnoreAcl)
                return true;

            if (!entity.SubjectToAcl)
                return true;

            return false;
        }

        #endregion
    }
}
