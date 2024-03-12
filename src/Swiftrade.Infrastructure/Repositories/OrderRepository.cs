using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Infrastructure.DbContexts;
using System.Linq;

namespace Swiftrade.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SwiftradeContext _preepexContext;
        public OrderRepository(SwiftradeContext preepexContext)
        {
            _preepexContext = preepexContext;
        }
        public IQueryable<Order> GetOrders()
        {
            return _preepexContext.Orders.AsQueryable();
        }
    }
}
