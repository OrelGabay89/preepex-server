using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Application.Interfaces.Shared;
using Swiftrade.Core.Domain.Entities.ApplicationEntities;
using System.Threading.Tasks;

namespace Swiftrade.Infrastructure.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        public BasketService(IBasketRepository basketRepository)
        { 
            _basketRepository = basketRepository;
        }

        public virtual async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _basketRepository.DeleteBasketAsync(basketId);
        }

        public virtual async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            return await _basketRepository.GetBasketAsync(basketId);
        }

        public virtual async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            return await _basketRepository.UpdateBasketAsync(basket);
        }
    }
}
