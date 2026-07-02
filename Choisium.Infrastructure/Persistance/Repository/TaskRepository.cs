using Choisium.Application.Abstraction.Repository;
using Choisium.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Choisium.Infrastructure.Persistance.Repository
{
    public class TaskRepository : BaseRepository<DecisionTask>, ITaskRepository
    {
        public TaskRepository(ChoisiumDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DecisionTask>> GetAllByProjectIdAsync(Guid projectId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(t => t.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<DecisionTask?> GetByIdAndProjectIdAsync(Guid taskId, Guid projectId)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == taskId && t.ProjectId == projectId);
        }
    }
}