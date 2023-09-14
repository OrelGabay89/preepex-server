using Preepex.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preepex.Core.Application.Interfaces.Repositories.Domain
{
    public interface IStoreRepository
    {
        Task<IList<Store>> GetAllAsync();
        Task DeleteAsync(Store store);
        Task<Store> GetByIdAsync(int storeId);
        Task InsertAsync(Store store);
        Task UpdateStoreAsync(Store store);
        IQueryable<Store> Table { get; }
    }
}
