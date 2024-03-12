using Microsoft.EntityFrameworkCore;
using Swiftrade.Core.Application.Interfaces.Repositories.Domain;
using Swiftrade.Core.Domain.Entities.Messages;
using Swiftrade.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swiftrade.Infrastructure.Repositories
{
    public class EmailAccountRepository : IEmailAccountRepository
    {
        private readonly ApplicationDbContext _context;
        public EmailAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(EmailAccount entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IList<EmailAccount>> GetAllAsync()
        {
            return await _context.EmailAccount.ToListAsync();
        }

        public async Task<EmailAccount> GetByIdAsync(int storeId)
        {
            return await _context.EmailAccount.SingleOrDefaultAsync(x => x.Id == storeId);
        }

        public async Task InsertAsync(EmailAccount entity)
        {
            _context.EmailAccount.Add(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<EmailAccount> Table()
        {
            return _context.EmailAccount.AsQueryable();
        }

        public async Task UpdateAsync(EmailAccount entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}