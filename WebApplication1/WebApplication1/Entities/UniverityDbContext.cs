using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities.Config;

namespace WebApplication1.Entities;

public class UniverityDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GroupEfConfig) );
    }
}