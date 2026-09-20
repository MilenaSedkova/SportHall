namespace ClientService.DataAccess.Models;

public class Record
{
    public Guid Id { get; set; }

    public Guid ClientId { get; set; }

    public Client Client { get; set; } = null!;

    public Guid CoachId { get; set; }

    public Coach Coach { get; set; } = null!;

    public DateTimeOffset StartTime { get; set; }

    public DateTimeOffset EndTime { get; set; }
}
