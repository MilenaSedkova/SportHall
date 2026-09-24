using Microsoft.EntityFrameworkCore;
using ClientService.DataAccess.Models;

namespace ClientService.DataAccess.ContextDb;

public class SportHallContext(DbContextOptions<SportHallContext> options) : DbContext(options)
{   
    public DbSet<Client> Clients { get; set; }

    public DbSet<Coach> Coaches { get; set; }

    public DbSet<Record> Records { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SportHallContext).Assembly);
    }
}
