using Choisium.Application.Abstraction.OtherService;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Choisium.Infrastructure.ExternalService
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId
        {
            get
            {
                var claim = _httpContextAccessor.HttpContext?.User
                    .FindFirst(ClaimTypes.NameIdentifier) // mapea al claim "sub" del JWT
                    ?? throw new UnauthorizedAccessException("Usuario no autenticado.");

                return Guid.Parse(claim.Value);
            }
        }
    }
}