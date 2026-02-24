using AuthService.Business.Interfaces;
using AuthService.DataAccess.Models;
using AuthService.Business.Utils;
using Microsoft.Extensions.Options;

namespace AuthService.Business.Services;

public class JwtTokenService(IOptions<JwtSettings> options)  : IJwtTokenService
{
    private readonly JwtSettings jwtSettings = options.Value;

    public string GenerateTokenForLogin(User user)
    { 
        var secretKey = Environment.GetEnvironmentVariable(JwtConstants.JwtKeyEnironment);

        var jwtGenerator = new JwtTokenGenerator(jwtSettings);

        return jwtGenerator.GenerateToken(
            email: user.Email,
            role: user.Role,
            id: user.Id
            );
    }
}