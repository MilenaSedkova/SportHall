namespace SeasonCardMicroService.DTOs
{
    public class SeasonCardDTO
    {
        public string Title { get; set; } = null!;
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
        public int CountOfVisit { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
