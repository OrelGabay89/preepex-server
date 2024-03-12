using System.Collections.Generic;
using System.Threading.Tasks;
using Swiftrade.Core.Domain.Entities;

namespace Swiftrade.Core.Application.Interfaces.Repositories.Domain
{
    public interface IProductAttributeRepository
    {
        Task<IList<ProductProductattributeMapping>> GetProductAttributeMappingsByProductIdAsync(int productId);
        Task<Productattribute> GetProductAttributeByIdAsync(int productAttributeId);
        Task<IList<Productattributevalue>> GetProductAttributeValuesAsync(int productAttributeMappingId);
    }
}
