using Swiftrade.Core.Domain.Entities;
using System.Linq;

namespace Swiftrade.Core.Application.Interfaces.Repositories.Domain
{
    public interface IProductCategoryRepository
    {
        IQueryable<ProductCategory> GetProductCategories();
    }
}
