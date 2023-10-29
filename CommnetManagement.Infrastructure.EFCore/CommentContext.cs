using CommentManagement.Domain.CommentAgg;
using CommnetManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CommnetManagement.Infrastructure.EFCore;

public class CommentContext : DbContext
{
    public CommentContext(DbContextOptions<CommentContext> options) : base(options)
    {
    }

    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(CommentMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }
}