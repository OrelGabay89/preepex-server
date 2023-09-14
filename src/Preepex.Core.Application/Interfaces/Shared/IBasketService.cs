using Preepex.Core.Domain.Entities.ApplicationEntities;
using System.Threading.Tasks;

namespace Preepex.Core.Application.Interfaces.Shared
{
    public interface IBasketService
    {
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
