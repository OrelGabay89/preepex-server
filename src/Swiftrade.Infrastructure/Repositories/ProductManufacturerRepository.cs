using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Infrastructure.DbContexts;
using System.Linq;

namespace Swiftrade.Infrastructure.Repositories
{
    public class ProductManufacturerRepository : IProductManufacturerRepository
    {
        private readonly SwiftradeContext _preepexContext;
        public ProductManufacturerRepository(SwiftradeContext preepexContext)
        {
            _preepexContext = preepexContext;
        }
        public IQueryable<ProductManufacturerMapping> GetProductManufactureres()
        {
           return _preepexContext.ProductManufacturerMappings.AsQueryable();

        }
    }
}
