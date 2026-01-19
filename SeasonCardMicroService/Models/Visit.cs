namespace SeasonCardMicroService.Models
{
    public class Visit
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long SubscriptionId { get; set; }
        public DateTime DateOfVisit { get; set; }
        public int CountOfEarnedBonuses { get; set; }
    }
}
