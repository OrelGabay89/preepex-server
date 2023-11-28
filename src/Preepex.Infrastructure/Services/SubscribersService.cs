using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Interfaces.Shared;
using Preepex.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Services
{
    public class SubscribersService : ISubscribersService
    {
        private readonly IGenericRepository<Subscriber> _subscriberRepository;

        public SubscribersService(IGenericRepository<Subscriber> subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
        }

        public async Task<Subscriber> GetSubscriberByIdAsync(int id)
        {
            return await _subscriberRepository.GetByIdAsync(id);
        }

        public async Task AddSubscriberAsync(Subscriber subscriber)
        {
            await _subscriberRepository.AddAsync(subscriber);
        }

        public async Task UpdateSubscriberAsync(Subscriber subscriber)
        {
            await _subscriberRepository.UpdateAsync(subscriber);
        }

        public async Task DeleteSubscriberAsync(Subscriber subscriber)
        {
            await _subscriberRepository.DeleteAsync(subscriber);
        }

        public async Task<IReadOnlyList<Subscriber>> GetAllSubscribersAsync()
        {
            return await _subscriberRepository.ListAllAsync();
        }
    }
}