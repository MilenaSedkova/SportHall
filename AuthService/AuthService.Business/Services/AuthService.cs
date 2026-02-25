using AuthService.Business.DTOs;
using AuthService.DataAccess.Interfaces;
using AuthService.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using AuthService.Business.Interfaces;

namespace AuthService.Business.Services;

public class AuthService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IJwtTokenService jwtTokenService): IAuthService
{
    private readonly IJwtTokenService jwtTokenService = jwtTokenService;

    public async Task<LoginResultDto> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(loginDto.Email, true, cancellationToken);

        if (user is null)
        {
            return new LoginResultDto(false, null, null, null, "User not found");
        }

        var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.PasswordHash);

        if (result is PasswordVerificationResult.Failed)
        {
            return new LoginResultDto(false, null, null, null, "Password is uncorrect");
        }

        var token = jwtTokenService.GenerateTokenForLogin(user);

        return new LoginResultDto(true, token, user.Id, user.RegistratedAt.ToDateTime(TimeOnly.MinValue), null);
    }

    public async Task<bool> RegisterAsync(RegisterDto registrationDTO, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = registrationDTO.Name,
            Surname = registrationDTO.Surname,
            Email = registrationDTO.Email,
            Role = registrationDTO.Role,
            RegistratedAt = DateOnly.FromDateTime(DateTime.UtcNow),
            PasswordHash = registrationDTO.PasswordHash
        };

        user.PasswordHash = passwordHasher.HashPassword(user, registrationDTO.PasswordHash);

        var result = await userRepository.CreateUserAsync(user, cancellationToken);

        return result is not null;
    }
}
