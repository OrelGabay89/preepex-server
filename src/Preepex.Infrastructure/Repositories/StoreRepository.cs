using Microsoft.EntityFrameworkCore;
using Preepex.Core.Application.Interfaces.Repositories.Domain;
using Preepex.Core.Domain.Entities;
using Preepex.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly PreepexContext _context;
        public StoreRepository(PreepexContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Store store)
        {
            _context.Entry(store).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Store>> GetAllAsync()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task<Store> GetByIdAsync(int storeId)
        {
            return await _context.Stores.SingleOrDefaultAsync(x => x.Id == storeId);
        }

        public async Task InsertAsync(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Store> Table => _context.Stores.AsQueryable();

        public async Task UpdateStoreAsync(Store store)
        {
            _context.Update(store);
            await _context.SaveChangesAsync();

        }
    }
}
