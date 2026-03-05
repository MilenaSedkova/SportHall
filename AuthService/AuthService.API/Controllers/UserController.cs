using AuthService.Business.DTOs;
using AuthService.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthService.API.RequestModels;
using AuthService.DataAccess.Enums;

namespace AuthService.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [Authorize(Roles = $"{nameof(UserRole.Admin)} , {nameof(UserRole.Coach)}")]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var user = await userService.GetByIdAsync(id, cancellationToken);
        return Ok(user);
    }

    [Authorize(Roles = $"{nameof(UserRole.Admin)} , {nameof(UserRole.Coach)}")]
    [HttpGet("email/{email}")]
    public async Task<ActionResult> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user = await userService.GetByEmailAsync(email, cancellationToken);
        return Ok(user);
    }

    [Authorize(Roles = $"{nameof(UserRole.Admin)} , {nameof(UserRole.Coach)}")]
    [HttpGet]
    public async Task<ActionResult> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var users = await userService.GetAllAsync(pageNumber, pageSize, cancellationToken);
        return Ok(users);
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpPut]
    public async Task<ActionResult<UpdateUserDto>> UpdateUserAsync([FromBody] UpdateUserDto updateUser, CancellationToken cancellationToken)
    {
        var user = await userService.UpdateUserAsync(updateUser, cancellationToken);
        return Ok(updateUser);
    }

    [HttpPut("{id:guid}/change-password")]
    public async Task<ActionResult> ChangePasswordAsync(Guid id, [FromBody] ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        var user = await userService.ChangePasswordAsync(id, request.NewPassword, cancellationToken);
        return Ok();
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpPut("{id:guid}/activateUser")]
    public async Task<ActionResult> ActivateUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userService.ActivateUserAsync(id, cancellationToken);
        return Ok();
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpPut("{id:guid}/deactivateUser")]
    public async Task<ActionResult> DeActivateUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userService.DeActivateUserAsync(id, cancellationToken);
        return Ok();
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userService.DeleteUserAsync(id, cancellationToken);
        return Ok();
    }
}
