using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Domain.Entities;
using System.Linq;

namespace Preepex.Infrastructure.Repositories
{
    public class ProductManufacturerRepository : IProductManufacturerRepository
    {
        private readonly PreepexContext _preepexContext;
        public ProductManufacturerRepository(PreepexContext preepexContext)
        {
            _preepexContext = preepexContext;
        }
        public IQueryable<ProductManufacturerMapping> GetProductManufactureres()
        {
           return _preepexContext.ProductManufacturerMappings.AsQueryable();

        }
    }
}
