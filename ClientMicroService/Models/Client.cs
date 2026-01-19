using AuthMicroService.Models;

namespace ClientMicroService.Models
{
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Surname { get; set; }
        public string? Email { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public DateOnly DateOfRegistrationToHall { get; set; }
    }
}
