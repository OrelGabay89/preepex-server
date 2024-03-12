using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Infrastructure.DbContexts;
using System.Linq;

namespace Swiftrade.Infrastructure.Repositories
{
    public class ProductWarehouseInventoryRepository : IProductWarehouseInventoryRepository
    {
        private readonly SwiftradeContext _preepexContext;

        public ProductWarehouseInventoryRepository(SwiftradeContext preepexContext)
        {
            _preepexContext = preepexContext;
        }

        public IQueryable<Productwarehouseinventory> Table()
        {
            return _preepexContext.Productwarehouseinventories;
        }
    }
}
