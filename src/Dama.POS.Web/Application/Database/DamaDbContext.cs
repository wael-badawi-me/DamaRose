using Dama.POS.Web.Features.Users;
using Microsoft.EntityFrameworkCore;

namespace Dama.POS.Web.Application.Database;

public class DamaDbContext(DbContextOptions<DamaDbContext> options) : DbContext(options) {
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DamaDbContext).Assembly);
    }
}
