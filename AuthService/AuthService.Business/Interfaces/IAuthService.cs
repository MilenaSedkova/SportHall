using AuthService.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Business.Interfaces;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterDto registrationDTO, CancellationToken cancellationToken);

    Task<LoginResultDto> LoginAsync(LoginDto loginDTO, CancellationToken cancellationToken);
}

