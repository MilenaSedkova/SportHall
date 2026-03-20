using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClientService.DataAccess.Models;

namespace ClientService.DataAccess.ContextDb;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> entity)
    {
        entity.Property(c=>c.Id).ValueGeneratedNever();
        entity.Property(c => c.Gender).HasConversion<string>();
    }
}
