using Swiftrade.Core.Domain.Entities.Common;
using System;
using System.Threading.Tasks;

namespace Swiftrade.Core.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity<int>;

        Task<int> Complete();
    }
}