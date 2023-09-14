using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Security;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Application.Interfaces.Shared.Customers;
using Preepex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Services.Topics
{
    public class TopicService : ITopicService
    {
        private readonly IWorkContext _workContext;
        private readonly ICustomerService _customerService;
        private readonly IGenericRepository<Topic> _topicRepository;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IAclService _aclService;

        public TopicService(IWorkContext workContext, ICustomerService customerService, IGenericRepository<Topic> topicRepository,
             IStoreMappingService storeMappingService, IAclService aclService)
        {
            _workContext = workContext;
            _customerService = customerService;
            _topicRepository = topicRepository;
            _storeMappingService = storeMappingService;
            _aclService = aclService;
        }

        /// <summary>
        /// Gets all topics
        /// </summary>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="ignoreAcl">A value indicating whether to ignore ACL rules</param>
        /// <param name="showHidden">A value indicating whether to show hidden topics</param>
        /// <param name="onlyIncludedInTopMenu">A value indicating whether to show only topics which include on the top menu</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the opics
        /// </returns>
        public virtual async Task<IList<Topic>> GetAllTopicsAsync(int storeId,
            bool ignoreAcl = false, bool showHidden = false, bool onlyIncludedInTopMenu = false)
        {
            var customer = await _workContext.GetCurrentCustomerAsync();
            var customerRoleIds = await _customerService.GetCustomerRoleIdsAsync(customer);

            return await _topicRepository.GetAllAsync(async query =>
            {
                if (!showHidden)
                    query = query.Where(t => t.Published);

                //apply store mapping constraints
                query = await _storeMappingService.ApplyStoreMapping(query, storeId);

                //apply ACL constraints
                if (!showHidden && !ignoreAcl)
                    query = await _aclService.ApplyAcl(query, customerRoleIds);

                if (onlyIncludedInTopMenu)
                    query = query.Where(t => t.IncludeInTopMenu);

                return query.OrderBy(t => t.DisplayOrder).ThenBy(t => t.SystemName);
            }, cache =>
            {
                return ignoreAcl
                    ? cache.PrepareKeyForDefaultCache(TopicDefaults.TopicsAllCacheKey, storeId, showHidden, onlyIncludedInTopMenu)
                    : cache.PrepareKeyForDefaultCache(TopicDefaults.TopicsAllWithACLCacheKey, storeId, showHidden, onlyIncludedInTopMenu, customerRoleIds);
            });
        }

        /// <summary>
        /// Gets all topics
        /// </summary>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="keywords">Keywords to search into body or title</param>
        /// <param name="ignoreAcl">A value indicating whether to ignore ACL rules</param>
        /// <param name="showHidden">A value indicating whether to show hidden topics</param>
        /// <param name="onlyIncludedInTopMenu">A value indicating whether to show only topics which include on the top menu</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the opics
        /// </returns>
        public virtual async Task<IList<Topic>> GetAllTopicsAsync(int storeId, string keywords,
            bool ignoreAcl = false, bool showHidden = false, bool onlyIncludedInTopMenu = false)
        {
            var topics = await GetAllTopicsAsync(storeId,
                ignoreAcl: ignoreAcl,
                showHidden: showHidden,
                onlyIncludedInTopMenu: onlyIncludedInTopMenu);

            if (!string.IsNullOrWhiteSpace(keywords))
            {
                return topics
                    .Where(topic => (topic.Title?.Contains(keywords, StringComparison.InvariantCultureIgnoreCase) ?? false) ||
                        (topic.Body?.Contains(keywords, StringComparison.InvariantCultureIgnoreCase) ?? false))
                    .ToList();
            }

            return topics;
        }
    }
}
