using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
    {
        // throw new NotImplementedException();
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Username)
        .IsRequired()
        .HasMaxLength(50)
        .HasColumnType("varchar(50)");

        builder.Property(u => u.Email)
        .IsRequired()
        .HasMaxLength(100)
        .HasColumnType("varchar(100)")
        .HasAnnotation("RegularExpression", @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        builder.Property(u => u.Password)
        .IsRequired()
        .HasMaxLength(16)
        .HasColumnType("varchar(16)");

        builder.HasMany(u => u.UserRoles)
        .WithOne(ur => ur.User)
        .HasForeignKey(ur => ur.UserId);
    }
}
