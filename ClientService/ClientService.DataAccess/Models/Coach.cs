namespace ClientService.DataAccess.Models;

public class Coach
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Specialization { get; set; }

    public ICollection<Record> Records { get; set; } = new List<Record>();
}
