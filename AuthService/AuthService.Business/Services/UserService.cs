using AuthService.Business.DTOs;
using AuthService.Business.Interfaces;
using AuthService.DataAccess.Interfaces;
using AuthService.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.Business.Mappers;
using AuthService.DataAccess.PagedResults;
using AuthService.Business.Utils;
using Microsoft.IdentityModel.Tokens;

namespace AuthService.Business.Services;

public class UserService(IUserRepository userRepository, IConfiguration configuration, IPasswordHasher<User> passwordHasher) : IUserService
{
    public async Task<UserForAdminDto?> GetByIdAsync(Guid id, bool isTracking, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(id, isTracking, cancellationToken);
        return user is null ? null : UserMapper.MapToAdminDto(user);
    }

    public async Task<UserForAdminDto?> GetByEmailAsync(string email, bool isTracking, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(email, isTracking, cancellationToken);
        return user is null ? null : UserMapper.MapToAdminDto(user);
    }

    public async Task<PagedUserResult<UserForAdminDto?>> GetAllAsync(int pageNumber, int pageSize, bool isTracking, CancellationToken cancellationToken)
    {
        var result = await userRepository.GetAllAsync(pageNumber, pageSize, isTracking, cancellationToken);
        return new PagedUserResult<UserForAdminDto?>(
            result.Items.Select(UserMapper.MapToAdminDto),
            result.PageNumber,
            result.PageSize,
            result.TotalCount
            );
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
        try
        {
            await userRepository.CreateUserAsync(user, cancellationToken);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<LoginResultDto> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(loginDto.Email, true, cancellationToken);

        if (user is null)
        {
            return new LoginResultDto(false, null, null, null, "User is not found");
        }

        var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.PasswordHash);

        if (result is PasswordVerificationResult.Failed)
        {
            return new LoginResultDto(false, null, null, null, "Password is uncorrect");
        }

        var jwtSettings = configuration.GetSection("JwtSettings");
        var secretKey = Environment.GetEnvironmentVariable(JwtConstants.JwtKeyEnironment);

        var jwtGenerator = new JwtTokenGenerator(configuration);

        var token = jwtGenerator.GenerateToken(
            email: user.Email,
            role: user.Role, 
            id: user.Id
            );

        return new LoginResultDto(true, token, user.Id, user.RegistratedAt.ToDateTime(TimeOnly.MinValue), null);
    }

    public async Task<UserForAdminDto> UpdateUserAsync(UpdateUserDto updateUser, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(updateUser.Id, true, cancellationToken) ?? throw new Exception("User is not found");

        user.Name = updateUser.Name ?? user.Name;
        user.Surname = updateUser.Surname ?? user.Surname;
        user.Email = updateUser.Email ?? user.Email;
        user.Role = updateUser.Role ?? user.Role;
        user.IsActive = updateUser.IsActive ?? user.IsActive;

        await userRepository.UpdateUserAsync(user, cancellationToken);

        return UserMapper.MapToAdminDto(user);
    }

    public async Task<bool> ChangePasswordAsync(Guid id, string newPassword, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(id, true, cancellationToken);

        if (user != null) 
        {
            return false;
        }

        user.PasswordHash = passwordHasher.HashPassword(user, newPassword);

        try
        {
            await userRepository.UpdateUserAsync(user, cancellationToken);
            return true;
        }

        catch
        {
            return false; 
        }
    }

    public async Task<bool> ActivateUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(id, true, cancellationToken);

        if (user is null)
        {
            return false;
        }

        user.IsActive = true;

        try
        {
            await userRepository.UpdateUserAsync(user, cancellationToken);
            return true;
        }
        catch
        {
            return false;
        }

    }

    public async Task<bool> DeActivateUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(id, true, cancellationToken);

        if (user is null)
        {
            return false;
        }

        user.IsActive = false;

        try
        {
            await userRepository.UpdateUserAsync(user, cancellationToken);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteUserAsync(Guid id, CancellationToken cancellationToken)
    {
            await userRepository.DeleteUserAsync(id, cancellationToken);
            return true;
    }
}

