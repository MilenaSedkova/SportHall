using AuthService.Business.DTOs;
using AuthService.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace AuthService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService userService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<LoginResultDto>> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken)
    {
        var user = await userService.LoginAsync(loginDto, cancellationToken);
        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterDto>> RegisterAsync(RegisterDto registerDto, CancellationToken cancellationToken)
    {
        var user = await userService.RegisterAsync(registerDto, cancellationToken);
        return Ok(user);
    }
}
