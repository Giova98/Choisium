using Choisium.Application.Abstraction.Repository;
using Choisium.Domain.Entity;
using Choisium.Infrastructure.Persistance.Repository;
using Microsoft.EntityFrameworkCore;

namespace Choisium.Infrastructure.Persistance
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ChoisiumDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Project>> GetAllByUserIdAsync(Guid userId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task<Project?> GetByIdAndUserIdAsync(Guid projectId, Guid userId)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == projectId && p.UserId == userId);
        }
    }
}