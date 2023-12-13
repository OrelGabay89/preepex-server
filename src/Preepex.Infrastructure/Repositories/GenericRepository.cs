using Microsoft.EntityFrameworkCore;
using Preepex.Core.Application.Caching;
using Preepex.Core.Application.Interfaces;
using Preepex.Core.Application.Specifications;
using Preepex.Core.Domain.Entities.Common;
using Preepex.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preepex.Infrastructure.Repositories
{
    public partial class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity<int>
    {
        //TODO  inject dbcontext 
        
        private readonly DbContext _context;
        private readonly IStaticCacheManager _staticCacheManager;

        public GenericRepository()
        {

        }
        public GenericRepository(dynamic applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public GenericRepository(PreepexContext context, IStaticCacheManager staticCacheManager)
        {
            _context = context;
            _staticCacheManager = staticCacheManager;
            
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IReadOnlyList<TEntity>> ListAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetEntityWithSpec(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpecificationEvaluator<TEntity>.GetQuery(_context.Set<TEntity>().AsQueryable(), spec);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public void UpdateRange(IList<TEntity> entity)
        {
            _context.Set<TEntity>().AttachRange(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IList<TEntity> entity)
        {
            _context.Set<TEntity>().RemoveRange(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IList<TEntity> entity)
        {
            _context.Set<TEntity>().RemoveRange(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> Table => _context.Set<TEntity>().AsQueryable();  
       
    }
}