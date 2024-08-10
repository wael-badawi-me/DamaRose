namespace Dama.POS.DAL.Handlers.Khood;


public class GetTByIdHandler<T> : HandlerBase, IRequestHandler<GetTByIdCommand<T>, T> where T : class
{
    public GetTByIdHandler(DbContextOptions<DamaRozePosContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public async Task<T> Handle(GetTByIdCommand<T> request, CancellationToken cancellationToken)
    {
        IQueryable<T> query = Context.Set<T>();

        return await query.FirstOrDefaultAsync(c => EF.Property<string>(c, "Id") == request.id, cancellationToken);
    }
}


public record GetTByIdCommand<T>(string id) : IRequest<T> where T : class;
