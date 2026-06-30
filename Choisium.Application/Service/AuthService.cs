using Choisium.Application.Abstraction.Repository;
using Choisium.Application.Abstraction.Service;
using Choisium.Application.Abstraction.OtherService;
using Choisium.Application.Common;           
using Choisium.Application.DTOs.Auth.Request;
using Choisium.Application.DTOs.Auth.Response;
using Choisium.Domain.Entity;

namespace Choisium.Application.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;

        public AuthService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<Result<AuthResponse>> SignUp(SignUpRequest request)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return Result<AuthResponse>.Failure("El correo electrónico ya está registrado.");
            }

            string hashedPassword = _passwordHasher.HashPassword(request.Password);

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                Email = request.Email,
                Password = hashedPassword
            };

            var createdUser = await _userRepository.CreateAsync(newUser);

            var tokenResult = _jwtService.GenerateToken(createdUser);

            var authResponse = new AuthResponse
            {
                Token = tokenResult.Token,
                UserId = createdUser.Id,
                FullName = createdUser.FullName,
                Email = createdUser.Email
            };

            return Result<AuthResponse>.Success(authResponse);
        }

        public async Task<Result<AuthResponse>> SignIn(SignInRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                return Result<AuthResponse>.Failure("Credenciales incorrectas.");
            }

            bool isPasswordValid = _passwordHasher.VerifyPassword(request.Password, user.Password);

            if (!isPasswordValid)
            {
                return Result<AuthResponse>.Failure("Credenciales incorrectas.");
            }

            var tokenResult = _jwtService.GenerateToken(user);

            var authResponse = new AuthResponse
            {
                Token = tokenResult.Token,
                UserId = user.Id,
                FullName = user.FullName,
                Email = user.Email
            };

            return Result<AuthResponse>.Success(authResponse);
        }
    }
}