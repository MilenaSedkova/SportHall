using AuthService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Business.Interfaces;

public interface IJwtTokenService
{
    string GenerateTokenForLogin(User user);
}
