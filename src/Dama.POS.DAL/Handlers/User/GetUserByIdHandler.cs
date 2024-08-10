namespace Dama.POS.DAL.Handlers.User;


public class GetTByIdHandler : HandlerBase, IRequestHandler<GetUserByIdCommand, Models.User>
{
    public GetTByIdHandler(DbContextOptions<DamaRozePosContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public async Task<Models.User> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
    {
        return await Context.Users.FirstOrDefaultAsync(c => c.Id == request.id, cancellationToken);
    }
}
public record GetUserByIdCommand(string id) : IRequest<Models.User>;
