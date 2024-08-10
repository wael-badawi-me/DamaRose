using System.Reflection;

namespace Dama.POS.DAL.Handlers.Khood;


public class InsertTHandler<T> : HandlerBase, IRequestHandler<InsertTCommand<T>> where T : class
{
    public InsertTHandler(DbContextOptions<DamaRozePosContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public async Task Handle(InsertTCommand<T> request, CancellationToken cancellationToken)
    {
        IQueryable<T> query = Context.Set<T>();

        var dbSet = Context.Set<T>();

        SetPropertyIfExists(request.entity, "CreatedBy", request.userId);
        SetPropertyIfExists(request.entity, "LastModifiedBy", request.userId);
        dbSet.Add(request.entity);

        await Context.SaveChangesAsync(cancellationToken);
    }
    private void SetPropertyIfExists(T entity, string propertyName, string value)
    {
        var property = entity.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
        if (property != null && property.CanWrite && property.PropertyType == typeof(string))
        {
            property.SetValue(entity, value);
        }
    }
}
public record InsertTCommand<T>(T entity, string userId) : IRequest where T: class;
