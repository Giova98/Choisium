using Choisium.Application.Abstraction.Repository;
using Choisium.Domain.Entity;
using Choisium.Infrastructure.Persistance.Repository;
using Microsoft.EntityFrameworkCore;

namespace Choisium.Infrastructure.Persistance
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ChoisiumDbContext context) : base(context)
        {
            
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return null;
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}