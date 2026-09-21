using ClientService.DataAccess.Enums;

namespace ClientService.DataAccess.Models;

public class Coach
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required CoachSpecialization Specialization { get; set; }

    public ICollection<Record> Records { get; set; } = new List<Record>();
}
