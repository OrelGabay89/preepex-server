using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Domain.Entities;
using Preepex.Infrastructure.DbContexts;
using System.Linq;

namespace Preepex.Infrastructure.Repositories
{
    public class ProductWarehouseInventoryRepository : IProductWarehouseInventoryRepository
    {
        private readonly PreepexContext _preepexContext;

        public ProductWarehouseInventoryRepository(PreepexContext preepexContext)
        {
            _preepexContext = preepexContext;
        }

        public IQueryable<Productwarehouseinventory> Table()
        {
            return _preepexContext.Productwarehouseinventories;
        }
    }
}
