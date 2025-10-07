using Microsoft.EntityFrameworkCore;
using Test003.Infrastructure.Persistence.Entities;

namespace Test003.Infrastructure.Persistence.DbContexts;

/// <summary>
/// PSQL database context
/// </summary>
public sealed class PsqlDbContext : DbContext
{
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    
    public PsqlDbContext(DbContextOptions<PsqlDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}