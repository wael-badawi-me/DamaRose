using Dama.POS.Web.Application.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dama.POS.Web.Features.Users.EditUser;

public record EditUserCommand(string CurrentUsername, string NewUsername) : IRequest;

public class EditUserHandler(DamaDbContext dbContext) : IRequestHandler<EditUserCommand> {
    public async Task Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.SingleAsync(x => x.Username == request.CurrentUsername, cancellationToken);

        user.Edit(request.NewUsername);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
