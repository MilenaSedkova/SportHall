using System.ComponentModel.DataAnnotations;

namespace AuthMicroService.DTOs
{
    public class RegistrDTO
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string name { get; set; } = null!;
        public string? surname { get; set; }
        [Required(ErrorMessage = "Введите Email")]
        public string email { get; set; } = null!;
        [Required(ErrorMessage = "Введите пароль")]
        public string password { get; set; } = null!;
        [Required(ErrorMessage = "Введите роль")]
        public string Role { get; set; } = null!;
    }
}
