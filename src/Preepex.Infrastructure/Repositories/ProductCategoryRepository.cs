using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Domain.Entities;
using Preepex.Infrastructure.DbContexts;
using System.Linq;

namespace Preepex.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly PreepexContext _preepexContext;
        public ProductCategoryRepository(PreepexContext preepexContext)
        {
            _preepexContext = preepexContext;
        }
        public IQueryable<ProductCategory> GetProductCategories()
        {
            return _preepexContext.ProductCategoryMappings.AsQueryable();
        }
    }
}
