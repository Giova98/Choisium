using Choisium.Application.Abstraction.Infrastructure;
using Choisium.Domain.Entity;
using Choisium.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Choisium.Infrastructure.Persistance
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ChoisiumDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ChoisiumDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            await SaveChangesAsync();
            return entity;
        }
        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await GetByIdAsync(id);

            if (existing == null)
            {
                return false;
            }

            _dbSet.Remove(existing);

            return await SaveChangesAsync();
        }

        protected async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseException(
                    "Error al acceder a la base de datos.",
                    ex
                );
            }
        }

    }
}