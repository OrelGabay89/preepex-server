using Preepex.Core.Application.Caching;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Domain.Entities;
using Preepex.Core.Domain.Entities.Catalog;
using Preepex.Core.Domain.Entities.Common;
using Preepex.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Preepex.Infrastructure.Services.Stores
{
    public class StoreMappingService : IStoreMappingService
    {
        private readonly IGenericRepository<Storemapping> _storeMappingRepository;
        private readonly CatalogSettings _catalogSettings;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IStoreContext _storeContext;

        public StoreMappingService(IGenericRepository<Storemapping> storeMappingRepository, CatalogSettings catalogSettings,IStaticCacheManager staticCacheManager, IStoreContext storeContext)
        {
            _storeMappingRepository = storeMappingRepository;
            _staticCacheManager = staticCacheManager;
            _storeContext = storeContext;
            _catalogSettings = catalogSettings;

        }

        public async Task<IQueryable<TEntity>> ApplyStoreMapping<TEntity>(IQueryable<TEntity> query, int storeId) where TEntity : BaseEntity<int>, IStoreMappingSupported
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            if (storeId == 0 || !await IsEntityMappingExistsAsync<TEntity>())
                return query;

            // Run this query first and bring the data into memory
            var storeMappings = await _storeMappingRepository.Table
                .Where(sm => sm.EntityName == typeof(TEntity).Name && sm.StoreId == storeId)
                .Select(sm => sm.EntityId)
                .ToListAsync();

            // Then run the second query, again filtered by storeMappings
            return query.Where(entity => !entity.LimitedToStores || storeMappings.Contains(entity.Id));
        }


      

        /// <summary>
        /// Get a value indicating whether a store mapping exists for an entity type
        /// </summary>
        /// <typeparam name="TEntity">Type of entity that supports store mapping</typeparam>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rue if exists; otherwise false
        /// </returns>
        protected virtual async Task<bool> IsEntityMappingExistsAsync<TEntity>() where TEntity : BaseEntity<int>
        {
            var entityName = typeof(TEntity).Name;
            //TODO implement caching this will be taken care of
            var key = _staticCacheManager.PrepareKeyForDefaultCache(PreepexStoreDefaults.StoreMappingExistsCacheKey, entityName);

            var query = from sm in _storeMappingRepository.Table
                        where sm.EntityName == entityName
                        select sm.StoreId;

            return await _staticCacheManager.GetAsync(key, query.Any);
        }

        /// <summary>
        /// Find store identifiers with granted access (mapped to the entity)
        /// </summary>
        /// <typeparam name="TEntity">Type of entity that supports store mapping</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the store identifiers
        /// </returns>
        public virtual async Task<int[]> GetStoresIdsWithAccessAsync<TEntity>(TEntity entity) where TEntity : BaseEntity<int>, IStoreMappingSupported
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityId = entity.Id;
            var entityName = entity.GetType().Name;

            var key = _staticCacheManager.PrepareKeyForDefaultCache(PreepexStoreDefaults.StoreMappingIdsCacheKey, entityId, entityName);

            var query = from sm in _storeMappingRepository.Table
                        where sm.EntityId == entityId &&
                              sm.EntityName == entityName
                        select sm.StoreId;

            return await _staticCacheManager.GetAsync(key, () => query.ToArray());
        }

        public Task DeleteStoreMappingAsync(Storemapping storeMapping)
        {
            throw new NotImplementedException();
        }



        public virtual async Task<bool> AuthorizeAsync<TEntity>(TEntity entity) where TEntity : BaseEntity<int>, IStoreMappingSupported
        {
            var store = await _storeContext.GetCurrentStoreAsync();

            return await AuthorizeAsync(entity, store.Id);
        }

        public virtual async Task<bool> AuthorizeAsync<TEntity>(TEntity entity, int storeId) where TEntity : BaseEntity<int>, IStoreMappingSupported
        {
            if (entity == null)
                return false;

            if (storeId == 0)
                //return true if no store specified/found
                return true;

            if (_catalogSettings.IgnoreStoreLimitations)
                return true;

            if (!entity.LimitedToStores)
                return true;

            foreach (var storeIdWithAccess in await GetStoresIdsWithAccessAsync(entity))
                if (storeId == storeIdWithAccess)
                    //yes, we have such permission
                    return true;

            //no permission found
            return false;
        }

        public Task<IList<Storemapping>> GetStoreMappingsAsync<TEntity>(TEntity entity) where TEntity : BaseEntity<int>, IStoreMappingSupported
        {
            throw new NotImplementedException();
        }

        public Task InsertStoreMappingAsync<TEntity>(TEntity entity, int storeId) where TEntity : BaseEntity<int>, IStoreMappingSupported
        {
            throw new NotImplementedException();
        }
    }
}
