using Preepex.Core.Domain.Entities.ApplicationEntities;
using Preepex.Core.Domain.Entities.OrderAggregate;
using System.Threading.Tasks;

namespace Preepex.Core.Application.Interfaces.Shared
{
    public interface IPaymentService
    {
        Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
        Task<OrigOrder> UpdateOrderPaymentSucceeded(string paymentIntentId);
        Task<OrigOrder> UpdateOrderPaymentFailed(string paymentIntentId);
    }
}