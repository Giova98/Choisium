using Choisium.Application.Abstraction.Repository;
using Choisium.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Choisium.Infrastructure.Persistance.Repository
{
    public class OptionRepository : BaseRepository<Option>, IOptionRepository
    {
        public OptionRepository(ChoisiumDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Option>> GetAllByTaskIdAsync(Guid taskId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(o => o.DecisionTaskId == taskId)
                .ToListAsync();
        }

        public async Task<Option?> GetByIdAndTaskIdAsync(Guid optionId, Guid taskId)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == optionId && o.DecisionTaskId == taskId);
        }

        public async Task<Option?> GetBestByTaskIdAsync(Guid taskId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(o => o.DecisionTaskId == taskId)
                .OrderByDescending(o => o.Score)
                .FirstOrDefaultAsync();
        }
    }
}