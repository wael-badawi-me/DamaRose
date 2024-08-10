namespace Dama.POS.DAL.Handlers.User;


public class GetUserByIdHandler : HandlerBase, IRequestHandler<GetUserByIdCommand, Models.User>
{
    public GetUserByIdHandler(DbContextOptions<DamaRozePosContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public async Task<Models.User> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
    {
        return await Context.Users.FirstOrDefaultAsync(c => c.Id == request.id);
    }
}
public record GetUserByIdCommand(string id) : IRequest<Models.User>;
