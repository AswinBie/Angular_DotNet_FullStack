using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        // throw new NotImplementedException();
        builder.ToTable("Blogs");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Title)
        .IsRequired()
        .HasMaxLength(100)
        .HasColumnType("varchar(100)");

        builder.Property(b => b.Content)
        .IsRequired()
        .HasMaxLength(500)
        .HasColumnType("varchar(500)");

        builder.Property(b => b.Image)
        .IsRequired();

        builder.Property(b => b.CreatedAt)
        .IsRequired()
        .HasColumnType("datetime")
        .HasDefaultValueSql("GETDATE()");

        builder.Property(b => b.UpdatedAt)
        .IsRequired()
        .HasColumnType("datetime")
        .HasDefaultValueSql("GETDATE()");

        builder.HasOne(b => b.User)
        .WithMany(u => u.Blogs)
        .HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.NoAction);
    }
}
