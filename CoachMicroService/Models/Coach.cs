using AuthMicroService.Models;

namespace CoachMicroService.Models
{
    public class Coach
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Surname { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Specilization { get; set; } = null!;
        public User? user { get; set; }

    }
}
