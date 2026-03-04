using AuthService.Business.DTOs;
using AuthService.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
            return result.ErrorMessage switch
            {
                "User not found" => NotFound(result),
                "Password is uncorrect" => Unauthorized(result),
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
