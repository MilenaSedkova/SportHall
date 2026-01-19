using ClientMicroService.Models;
using CoachMicroService.Models;

namespace SeasonCardMicroService.Models
{
    public class Subscription
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long? CoachId { get; set; }
        public string Title { get; set; } = null!;
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
        public int CountOfVisit { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
        public Client Client { get; set; }
    }
}