using AuthService.DataAccess.Models;

namespace AuthService.Business.Interfaces;

public interface IJwtTokenService
{
    string GenerateTokenForLogin(User user);
}