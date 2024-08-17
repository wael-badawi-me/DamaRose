using Dama.POS.DAL.Entities.Languages;
using Dama.POS.DAL.Entities.Orders;
using Dama.POS.DAL.Entities.Products;
using Dama.POS.DAL.Entities.RestaurantLayout;
using Dama.POS.DAL.Entities.Users;

namespace Dama.POS.DAL;

public class DamaRozeDbContext(DbContextOptions<DamaRozeDbContext> options) : DbContext(options)
{

    // Users
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }

    // Translations
    public virtual DbSet<Language> Languages { get; set; }
    public virtual DbSet<Translation> Translations { get; set; }

    // Restaurant Layout
    public virtual DbSet<Floor> Floors { get; set; }
    public virtual DbSet<Table> Tables { get; set; }
    public virtual DbSet<Location> Locations { get; set; }

    // Products
    public virtual DbSet<Menu> Menus { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Item> Items { get; set; }

    // Orders
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderDetail> OrderDetails { get; set; }
    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DamaRozeDbContext).Assembly);
    }
}
