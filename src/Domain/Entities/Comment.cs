using System;

namespace Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}
