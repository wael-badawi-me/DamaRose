using Dama.POS.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dama.POS.Web.Features.Users.EditUser;

public record EditUserCommand(string CurrentName, string NewName) : IRequest;

public class EditUserHandler(DamaRozeDbContext dbContext) : IRequestHandler<EditUserCommand> {
    public async Task Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.SingleAsync(x => x.Name == request.CurrentName, cancellationToken);

        user.Edit(request.NewName, true); // implement is enabled

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
