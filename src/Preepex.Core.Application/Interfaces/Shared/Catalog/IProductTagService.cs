using Preepex.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Preepex.Core.Application.Interfaces.Shared.Catalog
{
    public interface IProductTagService
    {
        Task<List<ProductTag>> GetAllProductTagsByProductIdAsync(int productId);
        Task<int> GetProductCountByProductTagIdAsync(int productTagId, int storeId, bool showHidden = false);
        Task<Dictionary<int, int>> GetProductCountAsync(int storeId, bool showHidden = false);
        Task<List<int>> GetProductIdsByTagNameAsync(string tagName);
        Task<IList<ProductTag>> GetAllProductTagsAsync(string tagName = null);
    }
}



