using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        // throw new NotImplementedException();
        builder.ToTable("Roles");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Name)
        .IsRequired()
        .HasMaxLength(50)
        .HasColumnType("varchar(50)");

        builder.HasMany(r => r.UserRoles)
        .WithOne(ur => ur.Role)
        .HasForeignKey(ur => ur.RoleId);

        builder.HasData(
            new Role { Id = 1, Name = "SuperAdmin" },
            new Role { Id = 2, Name = "Admin" },
            new Role { Id = 3, Name = "User" }
        );
    }
}
