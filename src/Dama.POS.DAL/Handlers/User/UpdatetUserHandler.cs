namespace Dama.POS.DAL.Handlers.User;


public class UpdatetUserHandler : HandlerBase, IRequestHandler<UpdatetUserCommand>
{
    public UpdatetUserHandler(DbContextOptions<DamaRozePosContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public async Task Handle(UpdatetUserCommand request, CancellationToken cancellationToken)
    {
        Models.User oldUser = await Context.Users.FirstOrDefaultAsync(c=>c.Id== request.user.Id);

        if (oldUser == null)
        {
            throw new ArgumentException("User with provided Id can't be found");
        }

        request.user.CreatedBy = oldUser.CreatedBy;
        request.user.CreatedDate = oldUser.CreatedDate;
        request.user.LastModifiedBy = request.userId;

        request.user.LastModifiedDate = DateTime.Now;

        Context.Entry(await Context.Set<Models.User>().FindAsync(request.user.Id)).State = EntityState.Detached;
        Context.Entry(request.user).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }
}
public record UpdatetUserCommand(Models.User user, string userId) : IRequest;
