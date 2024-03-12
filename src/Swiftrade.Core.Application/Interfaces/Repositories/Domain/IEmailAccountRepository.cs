using Swiftrade.Core.Domain.Entities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swiftrade.Core.Application.Interfaces.Repositories.Domain
{
    public interface IEmailAccountRepository
    {
        Task<IList<EmailAccount>> GetAllAsync();
        Task DeleteAsync(EmailAccount entity);
        Task<EmailAccount> GetByIdAsync(int id);
        Task InsertAsync(EmailAccount entity);
        Task UpdateAsync(EmailAccount entity);
        IQueryable<EmailAccount> Table();
    }
}