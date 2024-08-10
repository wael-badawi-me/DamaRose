using Dama.POS.DAL.Models;
using Dama.POS.Web.Application.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dama.POS.Web.Application;

public static class DependencyInjector {
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DAL.HandlerBase).Assembly));

        services.AddDbContext<DamaRozePosContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
