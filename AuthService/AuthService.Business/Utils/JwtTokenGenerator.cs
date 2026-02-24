using AuthService.DataAccess.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Business.Utils
{
    public class JwtTokenGenerator(JwtSettings jwtSettings)
    {
        public string GenerateToken(string email, UserRole role, Guid id)
        {
            var claimsForJwt = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role.ToString())
            };
   
            var secretKey = Environment.GetEnvironmentVariable(JwtConstants.JwtKeyEnironment);
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claimsForJwt,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings.ExpireTimesInMinutes)),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
