using System.ComponentModel.DataAnnotations;

namespace CoachMicroService.DTOs
{
    public class CreateCoachesDTO
    {
        [Required(ErrorMessage = "Укажите иям тренера")]
        public string Name { get; set; } = null!;
        public string? Surname { get; set; }
        [Required, EmailAddress(ErrorMessage = "Укажите Email")]
        public string Email { get; set; } = null!;
        [Required, MinLength(6)]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Укажите специлизацию тренера")]
        public string Specilization { get; set; } = null!;
    }
}
