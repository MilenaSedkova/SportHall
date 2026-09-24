using Microsoft.EntityFrameworkCore;
using ClientService.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.DataAccess.ContextDb;
public class CoachConfiguration :  IEntityTypeConfiguration<Coach>
{
    public void Configure(EntityTypeBuilder<Coach> entity)
    {
        entity.Property(c => c.Id).ValueGeneratedNever();
        entity.Property(c => c.Name).HasMaxLength(150);
        entity.Property(c => c.Specialization).HasConversion<string>();
    }
}
