using Dama.POS.DAL;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dama.POS.Web;

public static class DependencyInjector {
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddDbContext<DamaRozeDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
