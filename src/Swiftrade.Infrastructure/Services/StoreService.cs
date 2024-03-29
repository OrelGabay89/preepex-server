﻿using Microsoft.EntityFrameworkCore;
using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Application.Interfaces.Shared;
using Swiftrade.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swiftrade.Infrastructure.Services
{
    public class StoreService : IStoreService
    {

        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        /// <summary>
        /// Parse comma-separated Hosts
        /// </summary>
        /// <param name="store">Store</param>
        /// <returns>Comma-separated hosts</returns>
        protected virtual string[] ParseHostValues(Store store)
        {
            if (store == null)
                throw new ArgumentNullException(nameof(store));

            var parsedValues = new List<string>();
            if (string.IsNullOrEmpty(store.Hosts))
                return parsedValues.ToArray();

            var hosts = store.Hosts.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var host in hosts)
            {
                var tmp = host.Trim();
                if (!string.IsNullOrEmpty(tmp))
                    parsedValues.Add(tmp);
            }

            return parsedValues.ToArray();
        }

        /// <summary>
        /// Deletes a store
        /// </summary>
        /// <param name="store">Store</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteStoreAsync(Store store)
        {
            if (store == null)
                throw new ArgumentNullException(nameof(store));

            var allStores = await GetAllStoresAsync();
            if (allStores.Count == 1)
                throw new Exception("You cannot delete the only configured store");

            await _storeRepository.DeleteAsync(store);
        }

        /// <summary>
        /// Gets all stores
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stores
        /// </returns>
        public async Task<IList<Store>> GetAllStoresAsync()
        {
            var result = await _storeRepository.GetAllAsync();

            return result;
        }

        /// <summary>
        /// Gets a store 
        /// </summary>
        /// <param name="storeId">Store identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the store
        /// </returns>
        public async Task<Store> GetStoreByIdAsync(int storeId)
        {
            return await _storeRepository.GetByIdAsync(storeId);
        }

        /// <summary>
        /// Inserts a store
        /// </summary>
        /// <param name="store">Store</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertStoreAsync(Store store)
        {
            await _storeRepository.InsertAsync(store);
        }

        /// <summary>
        /// Updates the store
        /// </summary>
        /// <param name="store">Store</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateStoreAsync(Store store)
        {
            await _storeRepository.UpdateStoreAsync(store);
        }
        /// <summary>
        /// Indicates whether a store contains a specified host
        /// </summary>
        /// <param name="store">Store</param>
        /// <param name="host">Host</param>
        /// <returns>true - contains, false - no</returns>
        public virtual bool ContainsHostValue(Store store, string host)
        {
            if (store == null)
                throw new ArgumentNullException(nameof(store));

            if (string.IsNullOrEmpty(host))
                return false;

            var contains = ParseHostValues(store).Any(x => x.Equals(host, StringComparison.InvariantCultureIgnoreCase));

            return contains;
        }

        /// <summary>
        /// Returns a list of names of not existing stores
        /// </summary>
        /// <param name="storeIdsNames">The names and/or IDs of the store to check</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the list of names and/or IDs not existing stores
        /// </returns>
        public async Task<string[]> GetNotExistingStoresAsync(string[] storeIdsNames)
        {
            if (storeIdsNames == null)
                throw new ArgumentNullException(nameof(storeIdsNames));

            var query = _storeRepository.Table;
            var queryFilter = storeIdsNames.Distinct().ToArray();
            //filtering by name
            var filter = await query.Select(store => store.Name)
                .Where(store => queryFilter.Contains(store))
                .ToListAsync();
            queryFilter = queryFilter.Except(filter).ToArray();

            //if some names not found
            if (!queryFilter.Any())
                return queryFilter.ToArray();

            //filtering by IDs
            filter = await query.Select(store => store.Id.ToString())
                .Where(store => queryFilter.Contains(store))
                .ToListAsync();
            queryFilter = queryFilter.Except(filter).ToArray();

            return queryFilter.ToArray();
        }

        public Task<Store?> GetStoreByHostAsync(string host)
        {
            Console.WriteLine($"##[DEBUG]##: searching for {host} in the store repository");
            return _storeRepository.Table
                .Where(s => s.Hosts.ToLower().Contains(host))
                .FirstAsync();
        }

         

    }
}
