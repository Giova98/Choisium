using Choisium.Application.Common;
using Choisium.Application.DTOs.Auth.Request;
using Choisium.Application.DTOs.Auth.Response;

namespace Choisium.Application.Abstraction.Service
{
    public interface IAuthService
    {
        Task<Result<AuthResponse>> SignIn(SignInRequest request);
        Task<Result<AuthResponse>> SignUp(SignUpRequest request);
    }
}