using Swiftrade.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Swiftrade.Core.Application.Interfaces.Shared
{
    public interface ISubscribersService
    {
        Task<Subscriber> GetSubscriberByIdAsync(int id);
        Task AddSubscriberAsync(Subscriber subscriber);
        Task UpdateSubscriberAsync(Subscriber subscriber);
        Task DeleteSubscriberAsync(Subscriber subscriber);
        Task<IReadOnlyList<Subscriber>> GetAllSubscribersAsync();
    }
}