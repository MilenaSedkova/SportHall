using Microsoft.EntityFrameworkCore;
using ClientService.DataAccess.Models;

namespace ClientService.DataAccess.ContextDb;

public class ClientContext(DbContextOptions<ClientContext> options) : DbContext(options)
{   
    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientContext).Assembly);
    }
}
