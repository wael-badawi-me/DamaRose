namespace Dama.POS.DAL.Handlers.User;


public class SaveUserHandler : HandlerBase, IRequestHandler<SaveUserCommand>
{
    private readonly IMediator _mediator;
    public SaveUserHandler(DbContextOptions<DamaRozePosContext> dbContextOptions, IMediator mediator) : base(dbContextOptions)
    {
        _mediator = mediator;
    }

    public async Task Handle(SaveUserCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.user.Id))
        {
            request.user.Id = BTSID.BTSID.NewBase36Number(BTSID.NumberMode.Compressed);
            var insertUserCommand = new InsertUserCommand(request.user, request.userId);
            await _mediator.Send(insertUserCommand, cancellationToken);
        }
        else
        {
            var updateUserCommand = new UpdatetUserCommand(request.user, request.userId);
            await _mediator.Send(updateUserCommand, cancellationToken);
        }
    }
}
public record SaveUserCommand(Models.User user, string userId) : IRequest;
