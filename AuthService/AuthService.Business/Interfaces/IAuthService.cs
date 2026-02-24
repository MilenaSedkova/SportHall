using AuthService.Business.DTOs;

namespace AuthService.Business.Interfaces;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterDto registrationDTO, CancellationToken cancellationToken);

    Task<LoginResultDto> LoginAsync(LoginDto loginDTO, CancellationToken cancellationToken);

}