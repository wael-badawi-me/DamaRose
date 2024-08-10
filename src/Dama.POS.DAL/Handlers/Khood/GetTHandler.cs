namespace Dama.POS.DAL.Handlers.Khood;


public class GetTHandler<T> : HandlerBase, IRequestHandler<GetTCommand<T>, IQueryable<T>> where T : class
{
    public GetTHandler(DbContextOptions<DamaRozePosContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public async Task<IQueryable<T>> Handle(GetTCommand<T> request, CancellationToken cancellationToken)
    {
        Expression<Func<T, bool>> predicate = request.predicate ?? (c => true);
        
        IQueryable<T> query = Context.Set<T>();

        if (request.include != null)
        {
            foreach (string item in request.include)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    query = query.Include(item);
                }
            }
        }

        // Return the filtered query
        return query.Where(predicate);
    }
}
public record GetTCommand<T>(Expression<Func<T, bool>> predicate, List<string> include = null) : IRequest<IQueryable<T>> where T : class;
