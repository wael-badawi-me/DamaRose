namespace Dama.POS.DAL.Handlers.Khood;


public class DeleteTHandler<T> : HandlerBase, IRequestHandler<DeleteTCommand<T>> where T : class
{
    private readonly IMediator _mediator;

    public DeleteTHandler(DbContextOptions<DamaRozePosContext> dbContextOptions, IMediator mediator) : base(dbContextOptions)
    {
        _mediator = mediator;

    }

    public async Task Handle(DeleteTCommand<T> request, CancellationToken cancellationToken)
    {
        var getByIdCommand = new GetTByIdCommand<T>(request.id);
        var oldEntity = await _mediator.Send(getByIdCommand, cancellationToken);

        if (oldEntity == null)
        {
            throw new ArgumentException($"{typeof(T).Name} with provided Id can't be found");
        }
        Context.Set<T>().Remove(oldEntity);
        await Context.SaveChangesAsync(cancellationToken);
    }
}
public record DeleteTCommand<T>(string id) : IRequest where T:class;
