using InventoryManagement.Domain.InventoryAgg;
using InventoryMangement.Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace InventoryMangement.Infrastructure.EFCore;

public class InventoryContext : DbContext
{
    public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
    {
    }

    public DbSet<Inventory> Inventory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(InventoryMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }
}