using AuthService.DataAccess.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Business.Services;

public class JwtService(IConfiguration configuration)
{
    public string GenerateToken(string email, UserRole role, Guid id)
    {
        var claimsForJwt = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, id.ToString()),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, role.ToString())
        };

        var secretKey = Environment.GetEnvironmentVariable("JWT_KEY");
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["JwtSettings:Issuer"],
            audience: configuration["JwtSettings:Audience"],
            claims: claimsForJwt,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(configuration["JwtSettings:ExpireTimesInMinutes"])),
            signingCredentials: credentials
            );
       
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

