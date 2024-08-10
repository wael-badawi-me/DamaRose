namespace Dama.POS.DAL.Handlers.User;


public class GetUserHandler : HandlerBase, IRequestHandler<GetUserCommand, IQueryable<Models.User>>
{
    public GetUserHandler(DbContextOptions<DamaRozePosContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public async Task<IQueryable<Models.User>> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        Expression<Func<Models.User, bool>> predicate = request.predicate;
        if (predicate == null)
        {
            predicate = c => 1 == 1;
        }
        IQueryable<Models.User> query = Context.Users;
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
        return query.Where(predicate);
    }
}
public record GetUserCommand(Expression<Func<Models.User, bool>> predicate, List<string> include = null) : IRequest<IQueryable<Models.User>>;
