using AuthService.Business.DTOs;
using AuthService.Business.Interfaces;
using AuthService.DataAccess.Interfaces;
using AuthService.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using AuthService.Business.Mappers;
using AuthService.DataAccess.PagedResults;
using AuthService.Business.Exceptions;

namespace AuthService.Business.Services;

public class UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher) : IUserService
{
    public async Task<UserForAdminDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(id, isTracking: false, cancellationToken);
        return user is null
            ? throw new NotFoundException($"User with id {id} not found")
            : UserMapper.MapToAdminDto(user);
    }

    public async Task<UserForAdminDto?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(email, isTracking: false, cancellationToken);
        return user is null 
            ? throw new NotFoundException($"User with email {email} not found")
            : UserMapper.MapToAdminDto(user);
    }

    public async Task<PagedUserResult<UserForAdminDto?>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var result = await userRepository.GetAllAsync(pageNumber, pageSize, isTracking: false, cancellationToken);
        return new PagedUserResult<UserForAdminDto?>(
            result.Items.Select(UserMapper.MapToAdminDto),
            result.PageNumber,
            result.PageSize,
            result.TotalCount
            );
    }

    public async Task<UserForAdminDto> UpdateUserAsync(UpdateUserDto updateUser, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(updateUser.Id, true, cancellationToken)
            ?? throw new Exception($"User with id {updateUser.Id} not found");

        UserPatchMapper.ApplyMapping(user, updateUser);

        await userRepository.UpdateUserAsync(user, cancellationToken);

        return UserMapper.MapToAdminDto(user);
    }

    public async Task<bool> ChangePasswordAsync(Guid id, string newPassword, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(id, true, cancellationToken);

        if (!IsUserFound(user)) 
        {
            return false;
        }

        user!.PasswordHash = passwordHasher.HashPassword(user, newPassword);

        var result = await userRepository.UpdateUserAsync(user, cancellationToken);

        return result;
    }

    public async Task<bool> ActivateUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(id, true, cancellationToken);

        if (!IsUserFound(user))
        {
            return false;
        }

        user!.IsActive = true;

        var result = await userRepository.UpdateUserAsync(user, cancellationToken);

        return result;
    }

    public async Task<bool> DeActivateUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(id, true, cancellationToken);

        if (!IsUserFound(user))
        {
            return false;
        }

        user!.IsActive = false;

        var result = await userRepository.UpdateUserAsync(user, cancellationToken);

        return result;
    }

    public async Task<bool> DeleteUserAsync(Guid id, CancellationToken cancellationToken)
    {
           var result =  await userRepository.DeleteUserAsync(id, cancellationToken);

           return result;
    }

    private bool IsUserFound(User? user)
    {
        return user is not null; 
    }
}