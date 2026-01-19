using System.ComponentModel.DataAnnotations;

namespace AuthMicroService.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Введите Email")]
        [EmailAddress(ErrorMessage = "Некорректный формат Email")]
        public string email { get; set; } = null!;
        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля - 6 символов")]
        public string password { get; set; } = null!;
    }
}
