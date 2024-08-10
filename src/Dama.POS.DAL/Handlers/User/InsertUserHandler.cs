namespace Dama.POS.DAL.Handlers.User;


public class InsertUserHandler : HandlerBase, IRequestHandler<InsertUserCommand>
{
    public InsertUserHandler(DbContextOptions<DamaRozePosContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public async Task Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        request.user.CreatedBy = request.userId;
        request.user.LastModifiedBy = request.userId;
        Context.Users.Add(request.user);
        await Context.SaveChangesAsync();
    }
}
public record InsertUserCommand(Models.User user, string userId) : IRequest;
