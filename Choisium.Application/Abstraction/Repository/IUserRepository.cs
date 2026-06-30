using Choisium.Domain.Entity;

namespace Choisium.Application.Abstraction.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}