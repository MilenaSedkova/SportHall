using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Business.DTOs;

public record LoginResultDto(
     bool Succeeded,
     string? Token,
     Guid? Id,
     DateTime? RegistratedAt,
     string? ErrorMessage
);
