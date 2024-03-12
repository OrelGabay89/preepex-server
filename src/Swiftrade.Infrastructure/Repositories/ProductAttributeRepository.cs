using Microsoft.EntityFrameworkCore;
using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swiftrade.Infrastructure.Repositories
{
    public class ProductAttributeRepository : IProductAttributeRepository
    {
        private readonly SwiftradeContext _preepexContext;
        public ProductAttributeRepository(SwiftradeContext preepexContext)
        {
            _preepexContext = preepexContext;
        }
        public async Task<IList<ProductProductattributeMapping>> GetProductAttributeMappingsByProductIdAsync(int productId)
        {
            var query = await (from pam in _preepexContext.ProductProductattributeMappings
                               orderby pam.DisplayOrder, pam.Id
                               where pam.ProductId == productId
                               select pam).ToListAsync();

            return query;
        }
        public async Task<Productattribute> GetProductAttributeByIdAsync(int productAttributeId)
        {
            return await _preepexContext.Productattributes.FirstOrDefaultAsync(x => x.Id == productAttributeId);
        }
        public async Task<IList<Productattributevalue>> GetProductAttributeValuesAsync(int productAttributeMappingId)
        {
            var query = await (from pav in _preepexContext.Productattributevalues
                               orderby pav.DisplayOrder, pav.Id
                               where pav.ProductAttributeMappingId == productAttributeMappingId
                               select pav).ToListAsync();
            return query;
        }
    }
}
