using Swiftrade.Core.Application.Interfaces;
using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Application.Interfaces.Shared.Catalog;
using Swiftrade.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Swiftrade.Infrastructure.Services.Catalog
{
    public class ProductAttributeService : IProductAttributeService
    {
     
        private readonly IProductAttributeRepository _productAttributeRepository;
        public ProductAttributeService(IProductAttributeRepository productAttributeRepository)
        { 
            _productAttributeRepository = productAttributeRepository;
        }
        public async Task<Productattribute> GetProductAttributeByIdAsync(int productAttributeId)
        {
            return await _productAttributeRepository.GetProductAttributeByIdAsync(productAttributeId);
        }

        public async Task<IList<ProductProductattributeMapping>> GetProductAttributeMappingsByProductIdAsync(int productId)
        {
            return await _productAttributeRepository.GetProductAttributeMappingsByProductIdAsync(productId);
        }

        public async Task<IList<Productattributevalue>> GetProductAttributeValuesAsync(int productAttributeMappingId)
        {
            return await _productAttributeRepository.GetProductAttributeValuesAsync(productAttributeMappingId);
        }

        
    }
}
