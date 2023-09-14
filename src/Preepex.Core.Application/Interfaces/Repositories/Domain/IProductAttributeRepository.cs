using System.Collections.Generic;
using System.Threading.Tasks;
using Preepex.Core.Domain.Entities;

namespace Preepex.Core.Application.Interfaces.Repositories.Domain
{
    public interface IProductAttributeRepository
    {
        Task<IList<ProductProductattributeMapping>> GetProductAttributeMappingsByProductIdAsync(int productId);
        Task<Productattribute> GetProductAttributeByIdAsync(int productAttributeId);
        Task<IList<Productattributevalue>> GetProductAttributeValuesAsync(int productAttributeMappingId);
    }
}
