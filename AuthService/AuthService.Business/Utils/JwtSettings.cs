using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Business.Utils;

public class JwtSettings
{
    public required string Issuer { get; set; }

    public required string Audience { get; set; }

    public int ExpireTimesInMinutes { get; set; }
}


