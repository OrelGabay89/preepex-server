using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Infrastructure.DbContexts;
using System.Linq;

namespace Swiftrade.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly SwiftradeContext _preepexContext;
        public ProductCategoryRepository(SwiftradeContext preepexContext)
        {
            _preepexContext = preepexContext;
        }
        public IQueryable<ProductCategory> GetProductCategories()
        {
            return _preepexContext.ProductCategoryMappings.AsQueryable();
        }
    }
}
