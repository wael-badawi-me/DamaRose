using Microsoft.EntityFrameworkCore;
using Dama.POS.DAL.Models;

namespace Dama.POS.DAL;

public class HandlerBase
{
    public HandlerBase(DbContextOptions<DamaRozePosContext> dbContextOptions)
    {
        DbContextOptions = dbContextOptions;
    }
    private DamaRozePosContext context;
    public DamaRozePosContext Context
    {
        get
        {
            if (context == null)
            {
                context = new DamaRozePosContext(DbContextOptions);
            }
            return context;
        }
    }
    public DbContextOptions<DamaRozePosContext> DbContextOptions { get; }
}
