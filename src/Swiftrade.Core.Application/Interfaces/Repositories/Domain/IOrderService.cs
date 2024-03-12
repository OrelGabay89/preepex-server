using Swiftrade.Core.Domain.Entities.OrderAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Swiftrade.Core.Application.Interfaces.Repositories.Domain
{
    public interface IOrderService
    {
        Task<OrigOrder> CreateOrderAsync(string buyerEmail, int deliveryMethod, string basketId, OrigAddress shippingAddress);
        Task<IReadOnlyList<OrigOrder>> GetOrdersForUserAsync(string buyerEmail);
        Task<OrigOrder> GetOrderByIdAsync(int id, string buyerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}