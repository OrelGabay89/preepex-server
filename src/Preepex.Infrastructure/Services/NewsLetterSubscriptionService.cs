using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Services
{
    public class NewsLetterSubscriptionService : INewsLetterSubscriptionService
    {
        public Task DeleteNewsLetterSubscriptionAsync(NewsLetterSubscription newsLetterSubscription, bool publishSubscriptionEvents = true)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<NewsLetterSubscription>> GetAllNewsLetterSubscriptionsAsync(string email = null, DateTime? createdFromUtc = null, DateTime? createdToUtc = null, int storeId = 0, bool? isActive = null, int customerRoleId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public Task<NewsLetterSubscription> GetNewsLetterSubscriptionByEmailAndStoreIdAsync(string email, int storeId)
        {
            throw new NotImplementedException();
        }

        public Task<NewsLetterSubscription> GetNewsLetterSubscriptionByGuidAsync(Guid newsLetterSubscriptionGuid)
        {
            throw new NotImplementedException();
        }

        public Task<NewsLetterSubscription> GetNewsLetterSubscriptionByIdAsync(int newsLetterSubscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task InsertNewsLetterSubscriptionAsync(NewsLetterSubscription newsLetterSubscription, bool publishSubscriptionEvents = true)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNewsLetterSubscriptionAsync(NewsLetterSubscription newsLetterSubscription, bool publishSubscriptionEvents = true)
        {
            throw new NotImplementedException();
        }
    }
}
