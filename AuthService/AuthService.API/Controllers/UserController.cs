using AuthService.Business.DTOs;
using AuthService.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var user = await userService.GetByIdAsync(id, cancellationToken);
        return Ok(user);
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user = await userService.GetByEmailAsync(email, cancellationToken);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken cancellationToken)
    {
        var users = await userService.GetAllAsync(pageNumber, pageSize, cancellationToken);
        return Ok(users);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateUserDto>> UpdateUserAsync([FromBody] UpdateUserDto updateUser, CancellationToken cancellationToken)
    {
        var user = await userService.UpdateUserAsync(updateUser, cancellationToken);
        return Ok(updateUser);
    }

    [HttpPut("{id:guid}/change-password")]
    public async Task<IActionResult> ChangePasswordAsync(Guid id, [FromBody] string newPassword, CancellationToken cancellationToken)
    {
        var user = await userService.ChangePasswordAsync(id, newPassword, cancellationToken);
        return Ok();
    }

    [HttpPut("{id: guid} /activateUser")]
    public async Task<IActionResult> ActivateUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userService.ActivateUserAsync(id, cancellationToken);
        return Ok();
    }

    [HttpPut("{id: guid}/deactivateUser")]
    public async Task<IActionResult> DeActivateUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userService.DeActivateUserAsync(id, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id: guid}")]
    public async Task<IActionResult> DeleteUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userService.DeleteUserAsync(id, cancellationToken);
        return Ok();
    }
}
