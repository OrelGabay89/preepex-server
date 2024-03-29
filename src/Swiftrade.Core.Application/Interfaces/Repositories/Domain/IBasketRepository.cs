using Swiftrade.Core.Domain.Entities.ApplicationEntities;
using System.Threading.Tasks;

namespace Swiftrade.Core.Application.Interfaces.Repositories.Domain
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}