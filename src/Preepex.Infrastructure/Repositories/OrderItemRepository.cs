using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Domain.Entities;
using System.Linq;

namespace Preepex.Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly PreepexContext _preepexContext;
        public OrderItemRepository(PreepexContext preepexContext)
        {
            _preepexContext = preepexContext;
        }
        public IQueryable<Orderitem> GetOrderItems()
        {
            return _preepexContext.Orderitems.AsQueryable();
        }
    }
}
