using System;
using AuthService.Business.Enums;

namespace AuthService.Business.DTOs;

public record LoginResultDto(
     bool Succeeded,
     string? Token,
     Guid? Id,
     DateTime? RegistratedAt,
     string? ErrorMessage,
     LoginErrorType? ErrorType 
);
