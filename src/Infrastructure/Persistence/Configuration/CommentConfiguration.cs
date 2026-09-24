using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        // throw new NotImplementedException();
        builder.ToTable("Comments");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Content)
        .IsRequired()
        .HasMaxLength(500)
        .HasColumnType("varchar(500)");

        builder.Property(c => c.CreatedAt)
        .IsRequired()
        .HasColumnType("datetime")
        .HasDefaultValueSql("GETDATE()");

        builder.Property(c => c.UpdatedAt)
        .IsRequired()
        .HasColumnType("datetime")
        .HasDefaultValueSql("GETDATE()");

        builder.HasOne(c => c.User)
        .WithMany(u => u.Comments)
        .HasForeignKey(c => c.UserId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.Blog)
        .WithMany(b => b.Comments)
        .HasForeignKey(c => c.BlogId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}
