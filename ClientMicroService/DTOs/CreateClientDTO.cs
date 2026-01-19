using System.ComponentModel.DataAnnotations;

namespace ClientMicroService.DTOs
{
    public class CreateClientDTO
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string Name { get; set; } = null!;
        public string? Surname { get; set; }
        [Required, EmailAddress(ErrorMessage = "Введите email")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Введите дату рождения")]
        public DateOnly DateOfBirth { get; set; }
        public DateTime DateOfRegistrationToHall { get; set; } = DateTime.Now;
    }
}
