using AuthMicroService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthMicroService.ContextDb
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Name).IsRequired().HasMaxLength(128);

                entity.Property(u => u.Surname).HasMaxLength(128);

                entity.Property(u => u.Email).IsRequired().HasMaxLength(128);

                entity.Property(u => u.PasswordHash).IsRequired();

                entity.Property(u => u.IsActive).IsRequired();

                entity.Property(u => u.Role).HasConversion<string>().IsRequired();

                entity.Property(u => u.RegistratedAt).IsRequired();
            }
            );
        }
    }
}
