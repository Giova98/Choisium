using Choisium.Domain.Entity;

namespace Choisium.Application.Abstraction.OtherService
{
    public record InternalTokenResult(string Token, DateTime ExpiresAt);
    public interface IJwtService
    {
        InternalTokenResult GenerateToken(User user);
    }
}