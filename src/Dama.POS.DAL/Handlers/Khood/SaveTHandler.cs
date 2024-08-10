namespace Dama.POS.DAL.Handlers.Khood;


public class SaveTHandler<T> : HandlerBase, IRequestHandler<SaveTCommand<T>> where T : class
{
    private readonly IMediator _mediator;
    public SaveTHandler(DbContextOptions<DamaRozePosContext> dbContextOptions, IMediator mediator) : base(dbContextOptions)
    {
        _mediator = mediator;
    }

    public async Task Handle(SaveTCommand<T> request, CancellationToken cancellationToken)
    {
        var entityType = typeof(T);
        var keyProperty = Context.Model.FindEntityType(entityType).FindPrimaryKey().Properties[0];
        var entityId = keyProperty.PropertyInfo.GetValue(request.entity)?.ToString();
        if (string.IsNullOrEmpty(entityId))
        {
            keyProperty.PropertyInfo.SetValue(request.entity, BTSID.BTSID.NewBase36Number(BTSID.NumberMode.Compressed));
            var insertCommand = new InsertTCommand<T>(request.entity, request.userId);
            await _mediator.Send(insertCommand, cancellationToken);
        }
        else
        {
            var updateCommand = new UpdateTCommand<T>(request.entity, request.userId);
            await _mediator.Send(updateCommand, cancellationToken);
        }
    }
}
public record SaveTCommand<T>(T entity, string userId) : IRequest where T:class;
