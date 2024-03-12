using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Infrastructure.DbContexts;
using System.Linq;

namespace Swiftrade.Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly SwiftradeContext _preepexContext;
        public OrderItemRepository(SwiftradeContext preepexContext)
        {
            _preepexContext = preepexContext;
        }
        public IQueryable<Orderitem> GetOrderItems()
        {
            return _preepexContext.Orderitems.AsQueryable();
        }
    }
}
