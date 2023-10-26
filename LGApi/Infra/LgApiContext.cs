using LGApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LGApi.Infra;

public class LgApiContext : DbContext
{
    public DbSet<Conta> Contas { get; set; }

    public LgApiContext(DbContextOptions<LgApiContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}