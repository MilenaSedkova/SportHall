using AuthService.Business.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.DataAccess.Models;
using AuthService.Business.Utils;

namespace AuthService.Business.Services;

public class JwtTokenService(IConfiguration configuration)  : IJwtTokenService
{
    public string GenerateTokenForLogin(User user)
    {

        var jwtSettings = configuration.GetSection("JwtSettings");
        var secretKey = Environment.GetEnvironmentVariable(JwtConstants.JwtKeyEnironment);

        var jwtGenerator = new JwtTokenGenerator(configuration);

        return jwtGenerator.GenerateToken(
            email: user.Email,
            role: user.Role,
            id: user.Id
            );
    }
}
