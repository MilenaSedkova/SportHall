namespace SeasonCardMicroService.Models
{
    public class ClientEarnedBonuses
    {
        public long ClientId { get; set; }
        public int TotalEarned {  get; set; }
        public int TotalSpend {  get; set; }
        public int Available => TotalEarned - TotalSpend;
    }
}
