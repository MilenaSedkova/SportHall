using Microsoft.EntityFrameworkCore;
using ClientService.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.DataAccess.ContextDb;
public class RecordConfiguration : IEntityTypeConfiguration<Record>
{
    public void Configure(EntityTypeBuilder<Record> entity)
    {
        entity.Property(r => r.Id).ValueGeneratedNever();

        entity.HasOne(r => r.Client)
            .WithMany(с => с.Records)
            .HasForeignKey(r => r.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(r => r.Coach)
            .WithMany(с => с.Records)
            .HasForeignKey(r => r.CoachId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
