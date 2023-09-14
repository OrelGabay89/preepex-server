using Microsoft.EntityFrameworkCore;
using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Repositories
{
    public class ProductAttributeRepository : IProductAttributeRepository
    {
        private readonly PreepexContext _preepexContext;
        public ProductAttributeRepository(PreepexContext preepexContext)
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
