using AuthMicroService.Enums;

namespace AuthMicroService.DTOs
{
    public record UserForAdminDTO
    {
        Guid Id;
        string Name;
        string? Surname;
        string Email;
        UserRole Role;
        bool IsActive;
        DateOnly RegistratedAt;
    }
}
