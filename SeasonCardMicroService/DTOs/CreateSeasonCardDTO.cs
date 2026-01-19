using System.ComponentModel.DataAnnotations;

namespace SeasonCardMicroService.DTOs
{
    public class CreateSeasonCardDTO
    {
        [Required(ErrorMessage = "Введите имя клиента")]
        public long ClientId { get; set; }
        public long? CoachId { get; set; }
        [Required(ErrorMessage = "Введите описание абонемента")]
        public string Title { get; set; } = null!;
        [Range(1, 365, ErrorMessage = "Количество посещений должно быть от 1 до 365")]
        public int CountOfVisit { get; set; }
        [Required(ErrorMessage = "Укажите дату начала")]
        public DateTime DateOfStart { get; set; }
        [Required(ErrorMessage = "Укажите дату окончания")]
        public DateTime DateOfEnd { get; set; }
        [Required(ErrorMessage = "Укажите цену")]
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
