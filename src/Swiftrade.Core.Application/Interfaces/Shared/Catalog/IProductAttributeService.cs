using Swiftrade.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Swiftrade.Core.Application.Interfaces.Shared.Catalog
{
    public interface IProductAttributeService
    {
        Task<IList<ProductProductattributeMapping>> GetProductAttributeMappingsByProductIdAsync(int productId);
        Task<Productattribute> GetProductAttributeByIdAsync(int productAttributeId);
        Task<IList<Productattributevalue>> GetProductAttributeValuesAsync(int productAttributeMappingId);

    }
}
