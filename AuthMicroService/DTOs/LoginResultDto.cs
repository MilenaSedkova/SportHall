using AuthMicroService.Enums;

namespace AuthMicroService.DTOs;

 public record LoginResultDto(
     bool Succeeded,
     string? Token,
     Guid? Id,
     UserRole? Role,
     DateTime? RegistratedAt,
     string? ErrorMessage
);
    


