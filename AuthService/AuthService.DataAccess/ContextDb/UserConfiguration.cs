using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthService.DataAccess.Models;
using System.Reflection.Emit;

namespace AuthMicroService.ContextDb;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.Property(u => u.Id).ValueGeneratedNever();

        entity.Property(u => u.Role).HasConversion<string>();

        entity.HasIndex(u => u.Email).IsUnique();

    }
}
