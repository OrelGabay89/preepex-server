using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Preepex.Infrastructure
{/// <summary>
 /// Store context for web application
 /// </summary>
    public partial class WebStoreContext : IStoreContext
    {
        //TODO take care of IGenericAttributeService 
        //private readonly IGenericAttributeService _genericAttributeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStoreRepository _storeRepository;
        private readonly IStoreService _storeService;
        private readonly ILogger<WebStoreContext> _logger;
        private Store _cachedStore;



        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="genericAttributeService">Generic attribute service</param>
        /// <param name="httpContextAccessor">HTTP context accessor</param>
        /// <param name="storeRepository">Store repository</param>
        /// <param name="storeService">Store service</param>
        public WebStoreContext(IHttpContextAccessor httpContextAccessor,
            IStoreRepository storeRepository,
            IStoreService storeService,
            ILogger<WebStoreContext> logger

        )
        {
            //_genericAttributeService = genericAttributeService;
            _httpContextAccessor = httpContextAccessor;
            _storeRepository = storeRepository;
            _storeService = storeService;
            _logger = logger;
        }



        /// <summary>
        /// Gets the current store
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<Store> GetCurrentStoreAsync()
        {
            if (_cachedStore != null)
            {
                Console.WriteLine($"Using store {_cachedStore.Name} from cache");
                return _cachedStore;
            }

            string storeIdentifier = _httpContextAccessor.HttpContext.Request.Headers["swiftrade-store"];

            #if DEBUG
            storeIdentifier = "bambiboo";
            #endif

            var store = await _storeService.GetStoreByHostAsync(storeIdentifier);

            if (store != null) {
                _cachedStore = store;
                Console.WriteLine($"Using store {_cachedStore.Name}");
            } else {
                throw new Exception($"Coud't find store name {storeIdentifier}");
            }

            return _cachedStore;
        }

        /// <summary>
        /// Gets the current store
        /// </summary>
        public virtual Store GetCurrentStore()
        {
            if (_cachedStore != null)
                return _cachedStore;

            //try to determine the current store by HOST header
            string host = _httpContextAccessor.HttpContext?.Request.Headers[HeaderNames.Host];

            //we cannot call async methods here. otherwise, an application can hang. so it's a workaround to avoid that
            var allStores = _storeRepository.GetAllAsync().Result;

            var store = allStores.FirstOrDefault(s => _storeService.ContainsHostValue(s, host));

            if (store == null)
                //load the first found store
                store = allStores.FirstOrDefault();

            _cachedStore = store ?? throw new Exception("No store could be loaded");

            return _cachedStore;
        }

        /// <summary>
        /// Gets active store scope configuration
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        //public virtual async Task<int> GetActiveStoreScopeConfigurationAsync()
        //{
        //    if (_cachedActiveStoreScopeConfiguration.HasValue)
        //        return _cachedActiveStoreScopeConfiguration.Value;

        //    //ensure that we have 2 (or more) stores
        //    if ((await _storeService.GetAllStoresAsync()).Count > 1)
        //    {
        //        //do not inject IWorkContext via constructor because it'll cause circular references
        //        var currentCustomer = await EngineContext.Current.Resolve<IWorkContext>().GetCurrentCustomerAsync();

        //        //try to get store identifier from attributes
        //        var storeId = await _genericAttributeService
        //            .GetAttributeAsync<int>(currentCustomer, NopCustomerDefaults.AdminAreaStoreScopeConfigurationAttribute);

        //        _cachedActiveStoreScopeConfiguration = (await _storeService.GetStoreByIdAsync(storeId))?.Id ?? 0;
        //    }
        //    else
        //        _cachedActiveStoreScopeConfiguration = 0;

        //    return _cachedActiveStoreScopeConfiguration ?? 0;
        //}

    }
}

