namespace Dama.POS.DAL.Handlers.User;


public class DeleteUserHandler : HandlerBase, IRequestHandler<DeleteUserCommand>
{
    private readonly IMediator _mediator;

    public DeleteUserHandler(DbContextOptions<DamaRozePosContext> dbContextOptions, IMediator mediator) : base(dbContextOptions)
    {
        _mediator = mediator;

    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        GetUserByIdCommand getUserByIdCommand = new GetUserByIdCommand(request.userId);
        Models.User oldUser = await _mediator.Send(getUserByIdCommand);
        if (oldUser == null)
        {
            throw new ArgumentException("User with provided Id can't be found");
        }
        Context.Users.Remove(oldUser);
        await Context.SaveChangesAsync(cancellationToken);
    }
}
public record DeleteUserCommand(string userId) : IRequest;
