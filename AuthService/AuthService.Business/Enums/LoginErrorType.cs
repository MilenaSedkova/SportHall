using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Business.Enums;

public enum LoginErrorType
{
    None = 0, 
    NotFound = 1,
    IncorrectPassword = 2,
    Unknown = 3
}

