using AuthService.Business.DTOs;
using AuthService.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AuthService.Business.Enums;
namespace AuthService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<LoginResultDto>> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken)
    {
        var result = await authService.LoginAsync(loginDto, cancellationToken);
        if (!result.Succeeded)
        {
            return result.ErrorType switch
            {
                LoginErrorType.NotFound => NotFound(result),
                LoginErrorType.Unknown=> Unauthorized(result),
                _ => BadRequest(result),
            };
        }
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterDto>> RegisterAsync(RegisterDto registerDto, CancellationToken cancellationToken)
    {
        var result = await authService.RegisterAsync(registerDto, cancellationToken);
        return Ok();
    }
}
