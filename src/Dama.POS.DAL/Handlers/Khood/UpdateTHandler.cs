using System.Reflection;

namespace Dama.POS.DAL.Handlers.Khood;


public class UpdateTHandler<T> : HandlerBase, IRequestHandler<UpdateTCommand<T>> where T:class
{
    public UpdateTHandler(DbContextOptions<DamaRozePosContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public async Task Handle(UpdateTCommand<T> request, CancellationToken cancellationToken)
    {
        // Retrieve the existing entity by its ID
        var entityKey = Context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0];
        var entityId = entityKey.PropertyInfo.GetValue(request.entity);
        var oldEntity = await Context.Set<T>().FindAsync(new object[] { entityId }, cancellationToken);

        if (oldEntity == null)
        {
            throw new ArgumentException($"{typeof(T).Name} with provided Id can't be found");
        }

        CopyPropertyIfExists(request.entity, oldEntity, "CreatedBy");
        CopyPropertyIfExists(request.entity, oldEntity, "CreatedDate");

        SetPropertyIfExists(request.entity, "LastModifiedBy", request.userId);
        SetPropertyIfExists(request.entity, "LastModifiedDate", DateTime.Now);

        Context.Entry(oldEntity).State = EntityState.Detached;
        Context.Entry(request.entity).State = EntityState.Modified;
    }
    private void SetPropertyIfExists(T entity, string propertyName, object value)
    {
        var property = entity.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
        if (property != null && property.CanWrite)
        {
            property.SetValue(entity, value);
        }
    }
    private void CopyPropertyIfExists(T targetEntity, T sourceEntity, string propertyName)
    {
        var property = sourceEntity.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
        if (property != null && property.CanRead && property.CanWrite)
        {
            var value = property.GetValue(sourceEntity);
            property.SetValue(targetEntity, value);
        }
    }
}

public record UpdateTCommand<T>(T entity, string userId) : IRequest where T : class;
