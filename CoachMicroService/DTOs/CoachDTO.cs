namespace CoachMicroService.DTOs
{
    public class CoachDTO
    {
        public string Name { get; set; } = null!;
        public string? Surname { get; set; }
        public string Email { get; set; } = null!;
        public string? Specilization { get; set; }
        public string PhoneNumber { get; set; } = null!;
    }
}
