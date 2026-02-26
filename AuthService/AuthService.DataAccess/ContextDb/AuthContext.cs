using Microsoft.EntityFrameworkCore;
using AuthService.DataAccess.Models;

namespace AuthService.DataAccess.ContextDb;

public class AuthContext(DbContextOptions<AuthContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthContext).Assembly);
    }
}
