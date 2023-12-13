using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Domain.Entities;
using Preepex.Infrastructure.DbContexts;
using System.Linq;

namespace Preepex.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PreepexContext _preepexContext;
        public OrderRepository(PreepexContext preepexContext)
        {
            _preepexContext = preepexContext;
        }
        public IQueryable<Order> GetOrders()
        {
            return _preepexContext.Orders.AsQueryable();
        }
    }
}
